' التصميم المعماري الصحيح (قبل الكود)
'BLL
' ├── AppException.vb      (استثناء مخصص)
' ├── Logger.vb            (تسجيل الأخطاء)
' └── ErrorHandler.vb      (واجهة موحدة للعرض)

'وظــيفة هاذى الكلاس
'كلاس AppException(الاستثناء المخصص)
'• الوظيفة: يعمل كـ "هوية" للأخطاء التي تحدث داخل تطبيقك.
'• الهدف: يُستخدم لتمييز أخطاء البرنامج الخاصة (مثل "فشل تحديث بيانات الطالب") عن أخطاء النظام العامة (مثل أخطاء SQL أو IO)، مما يسهل على المبرمج معرفة مصدر المشكلة بدقة
Public Class AppException '(استثناء مخصص)
    Inherits Exception

    Public Sub New(message As String)
        MyBase.New(message)
    End Sub
    Public Sub New(message As String, inner As Exception)
        MyBase.New(message, inner)
    End Sub
    '    لماذا؟
    'نميز أخطاء التطبيق
    'نفصلها عن أخطاء النظام (SQL, IO…)
End Class
