ALTER PROC [dbo].[DSTK] 
@FROMDATE DATE, @TODATE DATE
AS
BEGIN 
	SELECT * FROM TAIKHOAN TK INNER JOIN (SELECT MACN FROM ChiNhanh) CN ON TK.MACN = CN.MACN WHERE NGAYTAOTK BETWEEN @FROMDATE AND @TODATE
END
--------------------------------------
ALTER proc [dbo].[find_KH_by_CMND] 
@CMND nchar(10)
as
begin 
	if exists(select cmnd from KhachHang where CMND =@CMND)
	begin 
		select cmnd from KhachHang where CMND =@CMND
	end
	else if exists(select cmnd from LINK0.NGANHANG.dbo.KhachHang where CMND =@CMND)
	begin
		select cmnd from LINK0.NGANHANG.dbo.KhachHang where CMND =@CMND
	end
end

---------------------------------------------
  ALTER   PROC [dbo].[find_nv_by_manv]
  @MANV nchar(10)
  as
  begin 
	if exists(select manv from NhanVien where MANV = @MANV)
	begin 
		select manv from NhanVien where MANV = @MANV
	end
	else
		if exists(select manv from LINK0.NGANHANG.dbo.NhanVien where MANV = @MANV)
		begin
			select manv from LINK0.NGANHANG.dbo.NhanVien where MANV = @MANV
		end
	end
	------------------------------------------
ALTER proc [dbo].[find_TK_by_STK] 
@STK nchar(10)
as
begin 
	if exists(select SOTK from TaiKhoan where SOTK =@STK)
	begin 
		select SOTK from TaiKhoan where SOTK =@STK
	end
end
---------------------------------------------
ALTER PROCEDURE [dbo].[MoTaiKhoanKH]
@SOTK nchar(9), @CMND nchar(10), @SODU money, @MACN nchar(10)
AS
BEGIN
	IF EXISTS (SELECT SOTK FROM TaiKhoan WHERE SOTK = @SOTK)
		BEGIN
			UPDATE TaiKhoan
				SET CMND = @CMND,
					SODU = @SODU
				WHERE SOTK = @SOTK
		END
	IF NOT EXISTS (SELECT SOTK FROM TaiKhoan WHERE SOTK = @SOTK)
		BEGIN
			INSERT INTO TaiKhoan (SOTK , CMND , SODU , MACN )
					VALUES (@SOTK , @CMND , @SODU , @MACN )
		END 
END
------------------------------------------------
ALTER PROCEDURE [dbo].[SP_CHUYENCONGTAC_SONGSONG]
  @MANVCU NVARCHAR(10), @MANV NVARCHAR(10), @MACN NCHAR(10) --@PASS VARCHAR(50)
AS
BEGIN
	SET XACT_ABORT ON 
	SET TRANSACTION ISOLATION LEVEL SERIALIZABLE;
	-- TAO 
	DECLARE @LGNAME VARCHAR(50);
	DECLARE @MANVCCC VARCHAR(50);
	--DECLARE @ROLE VARCHAR(50);
	--DECLARE @UID int;
	SELECT @LGNAME = SUSER_SNAME(sid) FROM sys.sysusers WHERE name = @MANVCU
	
	--SELECT @ROLE=NAME FROM sys.sysusers WHERE uid =(SELECT groupuid from sys.sysmembers WHERE memberuid = @UID)
	BEGIN DISTRIBUTED TRANSACTION;
	-- Check trang thai 
	IF EXISTS(SELECT MANV FROM LINK1.NGANHANG.dbo.NhanVien WHERE CMND = (SELECT CMND FROM NhanVien WHERE MANV = @MANVCU) AND TrangThaiXoa=1)
			BEGIN
			SELECT @MANVCCC = MANV FROM LINK1.NGANHANG.dbo.NhanVien WHERE CMND = (SELECT CMND FROM NhanVien WHERE MANV = @MANVCU) AND TrangThaiXoa=1
				UPDATE LINK1.NGANHANG.dbo.NhanVien
				SET TrangThaiXoa = 0
				WHERE MANV = @MANVCCC;
				--tạo lại login
				--EXEC LINK1.NGANHANG.DBO.SP_TAOLOGIN @LGNAME, @PASS, @USERNAME, @ROLE
				UPDATE NhanVien
				SET TrangThaiXoa = 1
				WHERE MANV = @MANVCU;
			END

	ELSE	
-- Update NHANVIEN from local instance.
	DECLARE @STR1 NVARCHAR(4000)
    SET @STR1='UPDATE NHANVIEN SET TrangThaiXoa = 1 WHERE MANV='''+ @MANVCU+''''
	DECLARE @STR2 NVARCHAR(4000)
    SET @STR2='exec Xoa_Login '''+ @LGNAME + ''', '''+@MANVCU +'''' 
    IF  EXISTS (SELECT job_id FROM msdb.dbo.sysjobs_view WHERE name = N'Job_1')
        EXEC msdb.dbo.sp_delete_job @job_name=N'Job_1' 
    
    execute msdb.dbo.sp_add_job @job_name = N'Job_1', @start_step_id = 1
    EXECUTE msdb.dbo.sp_add_jobserver  @job_name = N'Job_1', @server_name =  @@SERVERNAME
execute msdb.dbo.sp_add_jobstep  @job_name =  N'Job_1' , @step_id = 1, @step_name =    'xoa login', @command =  @STR2 ,   @server = @@SERVERNAME, @database_name = 'NGANHANG', @on_success_action = 3; 
    execute msdb.dbo.sp_add_jobstep  @job_name =  N'Job_1' , @step_id = 2, @step_name =    'chuyen cong tac nv', @command =  @STR1 ,   @server = @@SERVERNAME, @database_name = 'NGANHANG'
	
    execute msdb.dbo.sp_start_job    @job_name =  N'Job_1'
     
-- Update NHANVIEN from REMOTE instance. 
	--SET @USERNAME = @MANV
	INSERT INTO LINK1.NGANHANG.DBO.NhanVien (MANV, HO, TEN, CMND, DIACHI, PHAI, SODT, MACN, TRANGTHAIXOA)
		(
			SELECT MANV = @MANV, HO, TEN, CMND, DIACHI, PHAI, SODT, MACN = @MACN, TRANGTHAIXOA
			FROM dbo.NhanVien
			WHERE MANV = @MANVCU
		)
		--EXEC LINK1.NGANHANG.DBO.SP_TAOLOGIN @LGNAME, @PASS, @USERNAME, @ROLE
	--SELECT N'Đã Update xong'
	COMMIT TRANSACTION;
END
-------------------------------------------------------

ALTER PROC [dbo].[SP_CHUYENTIEN]
@STK_CHUYEN nchar(9), @STK_NHAN nchar(9), @SOTIEN money, @MANV nchar(10)
as
SET XACT_ABORT ON
SET TRANSACTION ISOLATION LEVEL SERIALIZABLE

	BEGIN TRY
		BEGIN TRANSACTION 
		INSERT INTO GD_CHUYENTIEN (SOTK_CHUYEN, SOTIEN,SOTK_NHAN, MANV) 
		VALUES(@STK_CHUYEN,@SOTIEN, @STK_NHAN, @MANV)
		UPDATE TaiKhoan SET SODU = SODU-@SOTIEN WHERE SOTK = @STK_CHUYEN
		UPDATE TaiKhoan SET SODU = SODU+@SOTIEN WHERE SOTK = @STK_NHAN
		COMMIT TRAN
	END TRY
	BEGIN CATCH
		IF (@@TRANCOUNT > 0)
		BEGIN
			ROLLBACK TRANSACTION
			DECLARE @ErrorMessage VARCHAR(2000)
			SELECT @ErrorMessage = 'Lỗi: ' + ERROR_MESSAGE()
			RAISERROR(@ErrorMessage, 16, 1)
		END
	END CATCH
--------------------------------------------------------
ALTER PROC [dbo].[SP_FIND_LOGIN_BY_ID]
@MA NCHAR(20)
AS
DECLARE @SID NCHAR(500) 
SELECT @SID = SID FROM SYS.sysusers WHERE NAME = @MA
SELECT NAME FROM SYS.SYSLOGINS WHERE SID = @SID
----------------------------------------
ALTER PROC [dbo].[SP_GUITIEN]
@STK NCHAR(9), @SOTIEN MONEY, @MANV NCHAR(10)
AS
SET XACT_ABORT ON
SET TRANSACTION ISOLATION LEVEL SERIALIZABLE
BEGIN TRY
	BEGIN TRANSACTION
		INSERT INTO GD_GOIRUT (SOTK, SOTIEN, LOAIGD, MANV) 
		VALUES( @STK, @SOTIEN, 'GT', @MANV)
		UPDATE TaiKhoan 
		SET SODU = SODU + @SOTIEN
		WHERE SOTK = @STK
	COMMIT TRAN
END TRY
BEGIN CATCH
	IF(@@TRANCOUNT > 0)
	BEGIN 
	ROLLBACK TRANSACTION
	DECLARE @ErrorMessage VARCHAR(2000)
	SELECT @ErrorMessage = 'Lỗi: ' + ERROR_MESSAGE()
	RAISERROR(@ErrorMessage, 16, 1)
	END
END CATCH
-------------------------------------------------
ALTER PROC [dbo].[SP_Lay_Thong_Tin_KH_Tu_Login]
@TENLOGIN NVARCHAR(100)
AS
DECLARE @UID INT
DECLARE @CMND NVARCHAR(100)
SELECT @UID= uid , @CMND= NAME FROM sys.sysusers 
  WHERE sid = SUSER_SID(@TENLOGIN)

SELECT CMND= @CMND, 
       HOTEN = (SELECT HO+ ' '+TEN FROM dbo.KhachHang WHERE CMND =@CMND ), 
       TENNHOM=NAME
  FROM sys.sysusers
    WHERE UID = (SELECT groupuid FROM sys.sysmembers WHERE memberuid=@uid
	-----------------------------------------------------
ALTER PROC [dbo].[SP_Lay_Thong_Tin_NV_Tu_Login]
@TENLOGIN NVARCHAR( 100)
AS
DECLARE @UID INT
DECLARE @MANV NVARCHAR(100)
SELECT @UID= uid , @MANV= NAME FROM sys.sysusers 
  WHERE sid = SUSER_SID(@TENLOGIN)

SELECT MAGV= @MANV, 
       HOTEN = (SELECT HO+ ' '+TEN FROM dbo.NHANVIEN WHERE MANV=@MANV ), 
       TENNHOM=NAME
  FROM sys.sysusers
    WHERE UID = (SELECT groupuid FROM sys.sysmembers WHERE memberuid=@uid)
---------------------------------------------------------------
ALTER PROC [dbo].[SP_RUTTIEN]
@STK NCHAR(9), @SOTIEN MONEY, @MANV NCHAR(10)
AS
SET XACT_ABORT ON
SET TRANSACTION ISOLATION LEVEL SERIALIZABLE
BEGIN TRY
	BEGIN TRANSACTION
		INSERT INTO GD_GOIRUT (SOTK, SOTIEN, LOAIGD, MANV) 
		VALUES( @STK, @SOTIEN, 'RT', @MANV)
		UPDATE TaiKhoan 
		SET SODU = SODU - @SOTIEN
		WHERE SOTK = @STK
	COMMIT TRAN
END TRY
BEGIN CATCH
	IF(@@TRANCOUNT > 0)
	BEGIN 
	ROLLBACK TRANSACTION
	DECLARE @ErrorMessage VARCHAR(2000)
	SELECT @ErrorMessage = 'Lỗi: ' + ERROR_MESSAGE()
	RAISERROR(@ErrorMessage, 16, 1)
	END
END CATCH
-----------------------------------------------ALTER PROC [dbo].[SP_TAOLOGIN]
  @LGNAME VARCHAR(50),
  @PASS VARCHAR(50),
  @USERNAME VARCHAR(50),
  @ROLE VARCHAR(50)
AS
  DECLARE @RET INT
  --TẠO LOGIN
  EXEC @RET= SP_ADDLOGIN @LGNAME, @PASS,'NGANHANG'
  IF (@RET =1)  -- LOGIN NAME BI TRUNG
     RETURN 1
  --TẠO USER
  EXEC @RET= SP_GRANTDBACCESS @LGNAME, @USERNAME
  IF (@RET =1)  -- USER  NAME BI TRUNG
  BEGIN
       EXEC SP_DROPLOGIN @LGNAME
       RETURN 2
  END
  --ADD ROLE CHO TÀI KHOẢN
  EXEC sp_addrolemember @ROLE, @USERNAME
  IF @ROLE= 'NGANHANG' OR @ROLE= 'CHINHANH'
  BEGIN 
    EXEC sp_addsrvrolemember @LGNAME, 'SecurityAdmin'
    EXEC sp_addsrvrolemember @LGNAME, 'ProcessAdmin'
  END
RETURN 0  -- THANH CONG
--------------------------------------------------
ALTER PROC [dbo].[SP_THONGKE_GD] 
@STK NCHAR(9), @TUNGAY DATE, @DENNGAY DATE
AS
BEGIN

DECLARE @SODU MONEY 
EXEC @SODU = TINHSD @TUNGAY, @STK
CREATE TABLE #TEMP (SODUDAU MONEY, NGAYGD DATETIME, LOAIGD NCHAR(2), SOTIEN MONEY, SODUSAU MONEY)

DECLARE @CUSOR CURSOR, @NGAYGD DATETIME, @LOAIGD NCHAR(2), @SOTIEN MONEY
SET @CUSOR = CURSOR FOR 
SELECT NGAYGD, LOAIGD, SOTIEN FROM LINK2.NGANHANG.DBO.GD_GOIRUT 
WHERE SOTK =@STK AND NGAYGD BETWEEN @TUNGAY AND @DENNGAY
UNION ALL 
SELECT NGAYGD, LOAIGD = 'CT', SOTIEN  FROM LINK2.NGANHANG.DBO.GD_CHUYENTIEN 
WHERE SOTK_CHUYEN = @STK AND NGAYGD BETWEEN @TUNGAY AND @DENNGAY
UNION ALL 
SELECT  NGAYGD, LOAIGD = 'NT', SOTIEN FROM LINK2.NGANHANG.DBO.GD_CHUYENTIEN 
WHERE SOTK_NHAN = @STK AND NGAYGD BETWEEN @TUNGAY AND @DENNGAY
ORDER BY NGAYGD ASC
OPEN @CUSOR
FETCH NEXT FROM @CUSOR INTO @NGAYGD, @LOAIGD, @SOTIEN
WHILE @@FETCH_STATUS =0 
BEGIN 
	IF(@LOAIGD = 'CT' OR @LOAIGD = 'RT')
	BEGIN 
		INSERT INTO #TEMP VALUES(@SODU, @NGAYGD, @LOAIGD, @SOTIEN, @SODU-@SOTIEN)
		SET @SODU = @SODU-@SOTIEN
	END

	ELSE 
	BEGIN 
		INSERT INTO #TEMP VALUES(@SODU, @NGAYGD, @LOAIGD, @SOTIEN, @SODU+@SOTIEN)
		SET @SODU = @SODU+@SOTIEN
	END
	FETCH NEXT FROM  @CUSOR INTO @NGAYGD, @LOAIGD, @SOTIEN
END
CLOSE @CUSOR
DEALLOCATE @CUSOR
SELECT * FROM #TEMP ORDER BY NGAYGD ASC
END

------------------------------------------------------------------
ALTER PROC [dbo].[TINHSD] (@NGAY DATE, @SOTK NCHAR(9) )
AS
BEGIN 
DECLARE @SODU MONEY
SELECT @SODU = SODU FROM TaiKhoan WHERE SOTK = @SOTK
DECLARE @GD CURSOR 
DECLARE @LOAIGD NCHAR(2)
DECLARE @SOTIEN MONEY

SET @GD = CURSOR FOR (SELECT LOAIGD, SOTIEN FROM LINK2.NGANHANG.DBO.GD_GOIRUT WHERE DATEDIFF(DAY, NGAYGD, @NGAY) <= 0 AND SOTK = @SOTK) 
OPEN @GD
FETCH NEXT FROM @GD INTO  @LOAIGD, @SOTIEN
WHILE @@FETCH_STATUS = 0
BEGIN 
	IF( @LOAIGD = 'GT' ) SET @SODU = @SODU - @SOTIEN
	ELSE SET @SODU = @SODU + @SOTIEN 
	FETCH NEXT FROM @GD INTO  @LOAIGD, @SOTIEN
END
CLOSE @GD
DEALLOCATE @GD
--
SELECT  @SODU = @SODU + sum(SOTIEN) FROM LINK2.NGANHANG.DBO.GD_CHUYENTIEN WHERE DATEDIFF(DAY, NGAYGD, @NGAY) <= 0 AND SOTK_CHUYEN = @SOTK
--
SELECT @SODU = @SODU - sum(SOTIEN) FROM LINK2.NGANHANG.DBO.GD_CHUYENTIEN WHERE DATEDIFF(DAY, NGAYGD, @NGAY) <= 0 AND SOTK_NHAN = @SOTK
RETURN @SODU
END
-----------------------------------------------------
ALTER PROC [dbo].[Xoa_Login]
  @LGNAME VARCHAR(50),
  @USRNAME VARCHAR(50)
  
AS
  EXEC SP_DROPUSER @USRNAME
  EXEC SP_DROPLOGIN @LGNAME


  ----------------------------------------------------------------------VIEW----------------------------------------------------------------------
CREATE VIEW [dbo].[DS_KHACHHANG] 
AS 
SELECT * FROM LINK2.NGANHANG.DBO.KHACHHANG ORDER BY MACN,TEN OFFSET 0 ROW 
GO

---------------
CREATE VIEW [dbo].[DSKH_CHUA_CO_TK_LOGIN] 
AS
SELECT * FROM LINK2.NGANHANG.DBO.KHACHHANG WHERE CMND NOT IN (SELECT NAME FROM LINK2.NGANHANG.sys.sysusers )
GO
----------------------

CREATE VIEW [dbo].[DSNV_CHUA_CO_TK_LOGIN] 
AS
SELECT * FROM NhanVien WHERE MANV NOT IN (SELECT NAME FROM sys.sysusers )
GO
--------------------------
CREATE VIEW [dbo].[Get_Subscribes_TC]
AS
SELECT TENCN=PUBS.description, TENSERVER=subscriber_server
FROM sysmergepublications  PUBS, sysmergesubscriptions SUBS
WHERE PUBS.description = 'TRACUU' AND PUBS.pubid = SUBS.pubid AND  publisher <> subscriber_server
GO


