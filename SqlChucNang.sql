﻿--DauSach---------------------------------------------------------------------
Create View View_DauSach as
Select* From DauSach
---------------------------------------------------------------------
Create Proc Proc_ThemDauSach 
@MaDS nvarchar(10),
@Ten nvarchar(100), 
@TheLoai nvarchar(50),
@MaTG varchar(10),
@MaNXB varchar(10)
as
Begin
Insert into DauSach(MaDS,Ten,TheLoai,MaTG,MaNXB) values (@MaDS,@Ten,@TheLoai,@MaTG,@MaNXB)
end
---------------------------------------------------------------------
Create Proc Proc_XoaDauSach 
@MaDS nvarchar(10)
as
Begin
Delete from DauSach Where MaDS=@MaDS
end
---------------------------------------------------------------------
CREATE PROCEDURE Proc_SuaDauSach
    @MaDS nvarchar(10),
    @Ten nvarchar(100), 
    @TheLoai nvarchar(50),
    @MaTG varchar(10),
    @MaNXB varchar(10)
AS
BEGIN
UPDATE DauSach
SET 
Ten = @Ten,
TheLoai = @TheLoai,
MaTG = @MaTG,
MaNXB = @MaNXB
WHERE MaDS = @MaDS;
END;
--Nha Xuat Ban---------------------------------------------------------------------
CREATE VIEW View_NhaXuatBan AS 
SELECT * 
FROM  dbo.NhaXuatBan
---------------------------------------------------------------------
CREATE PROCEDURE Proc_ThemNhaXuatBan
    @Ten NVARCHAR(100),
    @DiaChi NVARCHAR(255),
    @Email VARCHAR(100),
    @Sdt VARCHAR(10)
AS
BEGIN
    DECLARE @MaxMaNXB VARCHAR(10);
    DECLARE @NewMaNXB VARCHAR(10);
    DECLARE @NumericPart INT;

    -- Lấy mã NXB lớn nhất hiện có
    SELECT @MaxMaNXB = MAX(MaNXB)
    FROM NhaXuatBan
    WHERE MaNXB LIKE 'NXB%';

    -- Nếu không có mã nào, bắt đầu từ NXB001
    IF @MaxMaNXB IS NULL
        SET @NewMaNXB = 'NXB001';
    ELSE
    BEGIN
        -- Lấy phần số trong mã NXB hiện tại và tăng lên 1
        SET @NumericPart = CAST(SUBSTRING(@MaxMaNXB, 4, LEN(@MaxMaNXB) - 3) AS INT) + 1;

        -- Tạo mã NXB mới với định dạng NXB### (điền đủ 3 số)
        SET @NewMaNXB = 'NXB' + RIGHT('000' + CAST(@NumericPart AS VARCHAR(3)), 3);
    END

    -- Thêm nhà xuất bản mới vào bảng
    INSERT INTO NhaXuatBan (MaNXB, Ten, DiaChi, Email, Sdt)
    VALUES (@NewMaNXB, @Ten, @DiaChi, @Email, @Sdt);
END;
------------------------------------------------------------------------------------------------------------------------------------------
CREATE PROCEDURE Proc_XoaNhaXuatBan
	@MaNXB VARCHAR(10)
AS
BEGIN
	BEGIN TRANSACTION 
		BEGIN TRY 
			-- Xóa đầu sách theo MaNXB trong bảng DauSach
			DELETE FROM dbo.DauSach WHERE DauSach.MaNXB = @MaNXB
			--Xóa nhà xuất bản theo MaNXB trong bảng NhaXuatBan 
			DELETE FROM dbo.NhaXuatBan WHERE NhaXuatBan.MaNXB = @MaNXB
			COMMIT TRAN 
		END TRY 
 
		BEGIN CATCH 
			ROLLBACK 
			DECLARE @err NVARCHAR(MAX) 
			SELECT @err = N'Lỗi' + ERROR_MESSAGE() 
			RAISERROR(@err, 16, 1) 
		END CATCH
END
---------------------------------------------------------------------
CREATE PROCEDURE [dbo].[Proc_TimNhaXuatBan]     
    @Ten NVARCHAR(100)       
AS 
BEGIN 
    SELECT * 
    FROM dbo.NhaXuatBan
    WHERE Ten LIKE '%' + @Ten + '%'
END
---------------------------------------------------------------------
CREATE PROCEDURE Proc_SuaNhaXuatBan
	@MaNXB VARCHAR(10),      
    @Ten NVARCHAR(100),         
    @DiaChi NVARCHAR(255),      
    @Email VARCHAR(100),         
    @Sdt VARCHAR(10)
AS
BEGIN
	BEGIN TRY  
		UPDATE dbo.NhaXuatBan SET 
		Ten = @Ten,
		DiaChi = @DiaChi, 
		Email = @Email, 
		Sdt = @Sdt
		WHERE MaNXB = @MaNXB
	END TRY 
	BEGIN CATCH 
		DECLARE @err NVARCHAR(MAX) 
		SELECT @err = N'Lỗi' + ERROR_MESSAGE() 
		RAISERROR(@err, 16, 1) 
	END CATCH 
END
---------------------------------------------------------------------
CREATE TRIGGER TG_TrungTenNXB 
ON dbo.NhaXuatBan
AFTER INSERT, UPDATE 
AS 
BEGIN 
    -- Kiểm tra tên nhà xuất bản vừa thêm có bị trùng lặp 
    IF EXISTS ( 
        SELECT * 
        FROM inserted i 
        JOIN dbo.NhaXuatBan nxb 
        ON nxb.Ten = i.Ten 
        WHERE nxb.MaNXB <> i.MaNXB 
    ) 
    BEGIN 
        -- Nếu trùng thì rollback 
        RAISERROR ('Tên Nhà xuất bản bị trùng', 16, 1); 
        ROLLBACK TRANSACTION; 
    END 
END;

--Doc Gia---------------------------------------------------------------------
Create View View_DocGia as
Select* From DocGia;
---------------------------------------------------------------------
CREATE PROCEDURE Proc_ThemDocGia
    @GioiTinh NVARCHAR(10),
    @Ten NVARCHAR(100),
    @DiaChi NVARCHAR(255),
    @Email NVARCHAR(100),
    @Sdt NVARCHAR(10),
    @NgaySinh DATE
AS
BEGIN
    DECLARE @NewMaDG NVARCHAR(10);
    DECLARE @MaxMaDG NVARCHAR(10);
    DECLARE @NumberPart INT;
    SELECT @MaxMaDG = MAX(MaDG) 
    FROM DocGia
    WHERE MaDG LIKE 'MDG%';
    IF @MaxMaDG IS NOT NULL
    BEGIN
        SET @NumberPart = CAST(SUBSTRING(@MaxMaDG, 4, LEN(@MaxMaDG) - 3) AS INT);
        SET @NumberPart = @NumberPart + 1;
    END
    ELSE
    BEGIN
        SET @NumberPart = 1;
    END
    SET @NewMaDG = 'MDG' + RIGHT('000' + CAST(@NumberPart AS NVARCHAR(3)), 3);
    INSERT INTO DocGia(MaDG, GioiTinh, Ten, DiaChi, Email, Sdt, NgaySinh)
    VALUES (@NewMaDG, @GioiTinh, @Ten, @DiaChi, @Email, @Sdt, @NgaySinh);
END;
---------------------------------------------------------------------
Create Procedure Proc_XoaDocGia
      @MaDG NVARCHAR(10)
as
Begin
      Delete From DocGia
	  where MaDG = @MaDG;
end;
---------------------------------------------------------------------
Create Procedure Proc_SuaDocGia
     @MaDG NVARCHAR(10),
     @GioiTinh NVARCHAR(10),
     @Ten NVARCHAR(100),
     @DiaChi NVARCHAR(255),
     @Email NVARCHAR(100),
     @Sdt NVARCHAR(10),
     @NgaySinh DATE
as
Begin
      Update DocGia
	  Set
	  GioiTinh = @GioiTinh,
	  Ten = @Ten,
	  DiaChi = @DiaChi,
	  Email =@Email,
	  Sdt =@Sdt,
	  NgaySinh =@NgaySinh
	  Where MaDG =@MaDG;
end;
---------------------------------------------------------------------
CREATE FUNCTION Func_TimKiemDocGia
(
    @Ten NVARCHAR(100)
)
RETURNS TABLE
AS
RETURN
(
    SELECT MaDG, GioiTinh, Ten, DiaChi, Email, Sdt, NgaySinh
    FROM DocGia
    WHERE Ten LIKE '%' + @Ten + '%'
);
--ViTri---------------------------------------------------------------------
CREATE VIEW View_ViTri AS 
SELECT *  
FROM ViTri
---------------------------------------------------------------------
Create PROCEDURE Proc_ThemViTri 
    @KhuVuc nvarchar(20) = NULL,
    @Ke nvarchar(20) = NULL,
    @Ngan nvarchar(20) = NULL
AS
BEGIN
    DECLARE @NewMaVT nvarchar(10);
    SELECT @NewMaVT = MAX(MaVT) FROM ViTri;
    IF @NewMaVT IS NULL
        SET @NewMaVT = 'VT1';
    ELSE
        SET @NewMaVT = 'VT' + CAST(CAST(SUBSTRING(@NewMaVT, 3, LEN(@NewMaVT)-2) AS int) + 1 AS varchar);

    IF @KhuVuc IS NOT NULL AND @Ke IS NOT NULL AND @Ngan IS NOT NULL
    BEGIN
        INSERT INTO ViTri(MaVT, KhuVuc, Ke, Ngan) 
        VALUES (@NewMaVT, @KhuVuc, @Ke, @Ngan);
    END
    SELECT @NewMaVT AS NewMaVT;
END;
---------------------------------------------------------------------
Create proc Proc_XoaViTri
@MaVT nvarchar(10)
as
begin
DELETE FROM ViTri WHERE MaVT = @MaVT;
end;

create proc Proc_SuaViTri
@MaVT nvarchar(10),
@KhuVuc nvarchar(20),
@Ke nvarchar(20),
@Ngan nvarchar(20)
as
begin
UPDATE ViTri
            SET KhuVuc = @KhuVuc,
                Ke = @Ke,
                Ngan = @Ngan
            WHERE MaVT = @MaVT;
end;

CREATE FUNCTION Func_TimKiemViTri
(
    @MaVT nvarchar(10)
)
RETURNS TABLE
AS
RETURN
(
    SELECT *
    FROM ViTri
    WHERE MaVT = @MaVT
);

--TacGia---------------------------------------------------------------------
Create View View_TacGia as
Select* From TacGia;
---------------------------------------------------------------------
CREATE PROCEDURE Proc_ThemTacGia
    @Ten NVARCHAR(100),
    @Email NVARCHAR(100),
    @Sdt NVARCHAR(10)
AS
BEGIN
    DECLARE @NewMaTG NVARCHAR(10);  
    DECLARE @MaxMaTG NVARCHAR(10);
    DECLARE @NumberPart INT;
    SELECT @MaxMaTG = MAX(MaTG)
    FROM TacGia
    WHERE MaTG LIKE 'TG%';
    IF @MaxMaTG IS NOT NULL
    BEGIN
        SET @NumberPart = CAST(SUBSTRING(@MaxMaTG, 3, LEN(@MaxMaTG) - 2) AS INT);
        SET @NumberPart = @NumberPart + 1;
    END
    ELSE
    BEGIN
        SET @NumberPart = 1;
    END
    SET @NewMaTG = 'TG' + RIGHT('000' + CAST(@NumberPart AS NVARCHAR(3)), 3);
    INSERT INTO TacGia(MaTG, Ten, Email, Sdt)
    VALUES (@NewMaTG, @Ten, @Email, @Sdt);
END;
---------------------------------------------------------------------
Create Procedure Proc_XoaTacGia
      @MaTG NVARCHAR(10)
as
Begin
      Delete From TacGia
	  where MaTG = @MaTG;
end;
---------------------------------------------------------------------
Create Procedure Proc_SuaTacGia
     @MaTG NVARCHAR(50),  
     @Ten NVARCHAR(100),   
     @Email NVARCHAR(100),
     @Sdt NVARCHAR(20)
as
Begin
      Update TacGia
	  Set 
	  Ten = @Ten,	 
	  Email =@Email,
	  Sdt =@Sdt
	  Where MaTG =@MaTG;
end;
---------------------------------------------------------------------
CREATE FUNCTION Func_TimKiemTacGia
(
    @Ten NVARCHAR(100)
)
RETURNS TABLE
AS
RETURN
(
    SELECT MaTG, Ten, Email, Sdt
    FROM TacGia
    WHERE Ten LIKE '%' + @Ten + '%'
);
--CuonSach---------------------------------------------------------------------
CREATE VIEW View_ThongTinCuonSach AS
SELECT 
    cs.MaCS,                  
    ds.MaDS,                  
    vt.MaVT,                   
    ds.Ten AS TenDauSach,      
    nxb.Ten AS NhaXuatBan,      
    tg.Ten AS TacGia            
FROM 
    CuonSach cs
JOIN 
    DauSach ds ON cs.MaDS = ds.MaDS         
LEFT JOIN 
    NhaXuatBan nxb ON ds.MaNXB = nxb.MaNXB  
LEFT JOIN 
    TacGia tg ON ds.MaTG = tg.MaTG          
LEFT JOIN 
    ViTri vt ON cs.MaVT = vt.MaVT          
    

Create Procedure Proc_ThemCuonSach
     @MaCS NVARCHAR(10),
     @MaDS NVARCHAR(10),
     @MaVT NVARCHAR(10)   
As
Begin 
     Insert Into CuonSach(MaCS,MaDS,MaVT)
	 Values(@MaCS,@MaDS,@MaVT);
end;

Create Procedure Proc_XoaCuonSach
      @MaCS NVARCHAR(10)
as
Begin
      Delete From CuonSach
	  where MaCS = @MaCS;
end;

Create Procedure Proc_SuaCuonSach
     @MaCS NVARCHAR(10),
     @MaDS NVARCHAR(10),
     @MaVT NVARCHAR(10)   
As
begin
Update CuonSach
	  Set 
		MaDS = @MaDS,
		MaVT = @MaVT
	 Where MaCS = @MaCS;
end;
---------------------------------------------------------------------
