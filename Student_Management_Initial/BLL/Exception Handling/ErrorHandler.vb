'وظيـــفة هاذى الكلاس 
' (((يعتبر مركز قيادة  يستقبل كل الاخطاء وهو المكلف باالتقرير ماالذي يجب فعلة بحيث ينسق ماالذي يجب فعلة)))

'3. كلاس ErrorHandler (منظم الاستجابة)
'• الوظيفة: هو "الواجهة الموحدة" التي تربط كل شيء معاً

'الآلية:
'1. يستقبل الخطأ من أي مكان في البرنامج.
'    2. يستدعي الـ Logger لحفظ الخطأ في الملف النصي.
'    3. يقرر ما يظهر للمستخدم؛ فإذا كان الخطأ من نوع AppException يعرض الرسالة المخصصة، وإذا كان خطأً مجهولاً يعرض رسالة عامة مثل "حدث خطأ غير متوقع"
Public Class ErrorHandler '(عرض رسالة مناسبة للمستخدم)

    Public Shared Sub Handle(ex As Exception)
        Logger.Log(ex)

        If TypeOf ex Is AppException Then
            MsgBox(ex.Message, MsgBoxStyle.Critical, "خطأ") ' 
        Else
            MsgBox("حدث خطأ غير متوقع، يرجى مراجعة الدعم", MsgBoxStyle.Critical) 'Exception هاذى الرسالة تظهر اذى حدث الخطاء غير الاخطاء الموجودة في الكلاس 
        End If
    End Sub
End Class
