Imports Student_Management_Initial.Student_Management_Initial.Modul
Namespace Student_Management_Initial.BLL
    Public Class StudentValidator
        Public Shared Sub Validate(student As Student)
            If student Is Nothing Then
                Throw New Exception("الطالب غير موجود")
            End If

            If student.ID <= 0 Then
                Throw New Exception("رقم الطالب غير صالح")
            End If

            If String.IsNullOrWhiteSpace(student.Name) Then
                Throw New Exception("اسم الطالب مطلوب")
            End If

            If student.CurrentState Is Nothing Then
                Throw New Exception("حالة الطالب غير محددة")
            End If
        End Sub
    End Class
End Namespace

