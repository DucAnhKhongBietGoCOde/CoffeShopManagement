# ☕ QuanLyQuanCafe – Coffee Shop Management System

## 📌 Giới thiệu
**QuanLyQuanCafe** là phần mềm quản lý quán cà phê được xây dựng bằng **C# (WinForms)** và **SQL Server**.  
Hệ thống hỗ trợ quản lý bàn, món ăn, hóa đơn, nhân viên và thống kê doanh thu theo thời gian.

Đây là đồ án môn học nhằm rèn luyện kỹ năng:
- Thiết kế cơ sở dữ liệu
- Lập trình WinForms
- Làm việc với SQL Server (Stored Procedure, Trigger)
- Quản lý mã nguồn với GitHub

---

## 🛠️ Công nghệ sử dụng
- **Ngôn ngữ**: C# (.NET)
- **Giao diện**: WinForms
- **Cơ sở dữ liệu**: SQL Server
- **IDE**: Visual Studio 2022
- **Công cụ đóng gói**: Advanced Installer
- **Quản lý mã nguồn**: Git & GitHub

---

## 📂 Chức năng chính
- 🔐 Đăng nhập hệ thống (Admin / Nhân viên)
- 🪑 Quản lý bàn (Trống / Có người)
- 🍽️ Quản lý danh mục & món ăn
- 🧾 Tạo và quản lý hóa đơn
- 🔄 Chuyển bàn
- 💰 Thanh toán & áp dụng giảm giá
- 📊 Thống kê hóa đơn theo ngày

---

## 🗄️ Cơ sở dữ liệu
Hệ thống sử dụng các bảng chính:
- `USERS` – Tài khoản người dùng
- `TABLEFOOD` – Bàn
- `FOODS` – Món ăn
- `FOOD_CATEGORIES` – Loại món
- `BILLS` – Hóa đơn
- `BILL_INFO` – Chi tiết hóa đơn

📌 Toàn bộ cấu trúc bảng, **Stored Procedure**, **Trigger** được viết trong file:
