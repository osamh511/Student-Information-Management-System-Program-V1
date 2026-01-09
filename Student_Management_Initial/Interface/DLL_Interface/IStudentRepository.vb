Imports Student_Management_Initial.Student_Management_Initial.Interface.DLL_Interface
Imports Student_Management_Initial.Student_Management_Initial.Modul

Namespace Student_Management_Initial.Interface.DLL_Interface
    Public Interface IStudentRepository
        ' أضف هذا السطر في ملف IStudentRepository.vb
        Function ValidateLogin(username As String, password As String) As Boolean
        Sub Register(ByVal s As Student)

        Sub Update(student As Student)
        Sub Delete(studentId As Integer)

        Function GetAllStudents() As List(Of Student)
    End Interface
End Namespace

