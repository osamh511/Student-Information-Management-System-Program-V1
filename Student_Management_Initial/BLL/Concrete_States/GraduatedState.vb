Imports Student_Management_Initial.Student_Management_Initial.Interface

Namespace Student_Management_Initial.BLL.Concrete_States
    Public Class GraduatedState
        Implements IStudentState

        Public ReadOnly Property StatusName As String Implements IStudentState.StatusName
            Get
                Return "خريج"
            End Get
        End Property
    End Class
End Namespace