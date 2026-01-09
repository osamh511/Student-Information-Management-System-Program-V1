Imports System.IO
Imports System.Data.SqlClient
Imports System.Configuration
'وظــيفة هاذى الكلاس : FirstRunInitializer الذي يقوم بـ
'التحقق من بيئة النظام: التأكد من وجود مجلد البيانات
'Data في مسار التطبيق، وإنشائه إن لم يكن موجوداً.
'• تجهيز قاعدة البيانات: فحص وجود ملف StudentDB.mdf؛ فإذا كان التشغيل هو الأول، يقوم البرنامج بنسخ قاعدة البيانات من مجلد التطبيق إلى مجلد البيانات المخصص [3، 5].
'• ضمان الاستمرارية: في حال كانت القاعدة موجودة مسبقاً، يتخطى البرنامج هذه الخطوة ويكمل التشغيل طبيعياً لضمان الأداء 
Public Class FirstRunInitializer '1. تهيئة التشغيل الأول (First Run Initialization)
    Public Shared Sub EnsureDatabase()

        ' مسار مجلد البيانات
        Dim dataDir As String =
            Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Data") ' 1. تحديد مسار مجلد البيانات والتأكد من وجوده
        ' إنشاء المجلد تلقائياً
        If Not Directory.Exists(dataDir) Then
            Directory.CreateDirectory(dataDir) ' إنشاء المجلد إذا لم يكن موجوداً
        End If

        ' مسار ملف قاعدة البيانات
        ' التحقق من الجاهزية
        Dim dbPath As String = Path.Combine(dataDir, "StudentDB.mdf") ' 2. التحقق من وجود ملف قاعدة البيانات وتهيئته

        ' إذا كانت القاعدة موجودة → لا تفعل شيئًا
        ' إذا دخل الكود هنا، فهذا يعني أن البيئة جاهزة للاستخدام

        If File.Exists(dbPath) Then Return ' إذا كانت موجودة، أكمل التشغيل طبيعي
        ' النسخ التلقائي للملف لتهيئة العمل لأول مرة
        ' نسخ القاعدة من Resources
        ' أو من مجلد التطبيق
        ' إذا لم تكن موجودة، نبحث عن الملف الأصلي لنسخه
        Dim sourceDb As String =
            Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "StudentDB.mdf") '   ' النسخ التلقائي للملف لتهيئة العمل لأول مرة+  ... كود النسخ في حال عدم الوجود

        If Not File.Exists(sourceDb) Then
            Throw New AppException("ملف قاعدة البيانات غير موجود") ' معالجة الفشل:** إذا لم يجد ملف قاعدة البيانات الأصلي (Source) لنسخه، فإنه يقوم بإنشاء استثناء من نوع `AppException` لإيقاف البرنامج وإبلاغ المستخدم بوجود مشكلة 
        End If
        ' هنا يتم الإعداد التلقائي
        File.Copy(sourceDb, dbPath) ' ' هنا يتم الإعداد التلقائي  +  هذا السطر يعني **نسخ ملف قاعدة البيانات الخام** من مجلد التطبيق الرئيسي (حيث يوجد ملف EXE) إلى مجلد البيانات الدائم (Data Folder)

    End Sub
End Class
