' 1. عقد الحالة (Interface)
Namespace Student_Management_Initial.Interface
    Public Interface IStudentState 'تعمل كجسر يربط بين المنطق البرمجي الداخلي وبين ما يراه المستخدم في واجهة التطبيق
        ReadOnly Property StatusName As String
    End Interface
End Namespace


