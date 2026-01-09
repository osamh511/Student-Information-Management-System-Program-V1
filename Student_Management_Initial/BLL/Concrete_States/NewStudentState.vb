Imports Student_Management_Initial.Student_Management_Initial.Interface

Namespace Student_Management_Initial.BLL.Concrete_States
    Public Class NewStudentState
        Implements IStudentState

        ' الحل: استخدام Get Block بدلاً من السهم =>
        Public ReadOnly Property StatusName As String Implements IStudentState.StatusName
            Get
                Return "مستجد"
            End Get
        End Property
    End Class
End Namespace