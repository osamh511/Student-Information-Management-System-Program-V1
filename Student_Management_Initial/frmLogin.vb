Imports Student_Management_Initial.Student_Management_Initial.Interface.DLL_Interface

Public Class frmLogin
    Private ReadOnly _repo As IStudentRepository

    'حقن التبعية(Dependency Injection): بدل أن يقوم الفورم بنفسه بإنشاء المستودع داخليًا، يتم تمرير المستودع له كمعامل في الـ Constructor
    Public Sub New(repo As IStudentRepository)
        InitializeComponent()
        _repo = repo
    End Sub

    Private Sub btnLogin_Click(sender As Object, e As EventArgs) Handles btnLogin.Click
        If _repo.ValidateLogin(txtUser.Text, txtPass.Text) Then
            ' إذا نجح الدخول، نفتح الفورم الرئيسي
            Me.Hide()
            Dim mainForm As New frmStudentManagervb(_repo)
            mainForm.ShowDialog()
            Me.Close()
        Else
            MsgBox("اسم المستخدم أو كلمة السر غير صحيحة!", MsgBoxStyle.Critical)
        End If
    End Sub
End Class