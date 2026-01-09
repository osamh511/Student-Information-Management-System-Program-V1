# Student Management System (VB.NET)

مشروع لإدارة الطلاب باستخدام **VB.NET** مع تطبيق أنماط التصميم (Design Patterns) مثل **State Pattern** وحقن التبعية (Dependency Injection).  
يوفر النظام واجهة رسومية (WinForms) مع ربط مباشر بقاعدة بيانات **SQL Server** عبر ADO.NET.

## المزايا
- تسجيل الدخول عبر شاشة مخصصة (Login Form).
- إدارة بيانات الطلاب (إضافة، تعديل، حذف).
- دعم حالات الطالب (مستجد، خريج) باستخدام **State Pattern**.
- التحقق من صحة البيانات عبر طبقة الأعمال (BLL).
- مستودع بيانات (Repository) قابل للتبديل بين قائمة داخلية وSQL Server.
- عرض البيانات في **DataGridView** مع ربط ديناميكي باستخدام LINQ.

## البنية المعمارية
- **Interface Layer**: تعريف العقود (IStudentState, IStudentRepository).
- **BLL (Business Logic Layer)**: التحقق من البيانات وإدارة الحالات.
- **DLL (Data Access Layer)**: مستودع SQL باستخدام إجراءات مخزنة (Stored Procedures).
- **UI Layer**: واجهة المستخدم (WinForms) مع حقن التبعية.

## المتطلبات
- .NET 9.0 (Windows 7.0 Target).
- SQL Server مع قاعدة بيانات `StudentDB`.
- مكتبة `Microsoft.Data.SqlClient`.

## طريقة التشغيل
1. تأكد من إعداد قاعدة البيانات وإنشاء الإجراءات المخزنة (`sp_RegisterStudent`, `sp_CheckLogin`).
2. افتح المشروع في **Visual Studio**.
3. شغّل التطبيق، وابدأ من شاشة تسجيل الدخول.
