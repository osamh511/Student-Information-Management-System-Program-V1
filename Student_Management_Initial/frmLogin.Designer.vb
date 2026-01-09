<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmLogin
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        txtPass = New TextBox()
        txtUser = New TextBox()
        Label1 = New Label()
        Label2 = New Label()
        btnLogin = New Button()
        Label3 = New Label()
        Label4 = New Label()
        SuspendLayout()
        ' 
        ' txtPass
        ' 
        txtPass.ForeColor = Color.FromArgb(CByte(0), CByte(192), CByte(0))
        txtPass.Location = New Point(345, 196)
        txtPass.Multiline = True
        txtPass.Name = "txtPass"
        txtPass.Size = New Size(160, 33)
        txtPass.TabIndex = 0
        ' 
        ' txtUser
        ' 
        txtUser.ForeColor = Color.FromArgb(CByte(0), CByte(192), CByte(0))
        txtUser.Location = New Point(345, 130)
        txtUser.Multiline = True
        txtUser.Name = "txtUser"
        txtUser.Size = New Size(160, 38)
        txtUser.TabIndex = 1
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Font = New Font("Segoe UI", 9F, FontStyle.Bold)
        Label1.Location = New Point(532, 144)
        Label1.Name = "Label1"
        Label1.Size = New Size(78, 15)
        Label1.TabIndex = 2
        Label1.Text = "اسم المستخدم"
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.Font = New Font("Segoe UI", 9F, FontStyle.Bold)
        Label2.Location = New Point(523, 214)
        Label2.Name = "Label2"
        Label2.Size = New Size(54, 15)
        Label2.TabIndex = 3
        Label2.Text = "كلمة السر"
        ' 
        ' btnLogin
        ' 
        btnLogin.Font = New Font("Segoe UI", 9F, FontStyle.Bold)
        btnLogin.ForeColor = Color.Red
        btnLogin.Location = New Point(385, 287)
        btnLogin.Name = "btnLogin"
        btnLogin.Size = New Size(101, 38)
        btnLogin.TabIndex = 4
        btnLogin.Text = "دخول"
        btnLogin.UseVisualStyleBackColor = True
        ' 
        ' Label3
        ' 
        Label3.AutoSize = True
        Label3.BackColor = Color.FromArgb(CByte(192), CByte(64), CByte(0))
        Label3.Font = New Font("Segoe UI", 11F, FontStyle.Bold)
        Label3.Location = New Point(324, 24)
        Label3.Name = "Label3"
        Label3.Size = New Size(200, 40)
        Label3.TabIndex = 5
        Label3.Text = "تصميم  برنامج  (أدارة الطلاب)" & vbCrLf & "عمل ألمبرمج / أسـامة ألعميسي" & vbCrLf
        ' 
        ' Label4
        ' 
        Label4.AutoSize = True
        Label4.BackColor = Color.FromArgb(CByte(192), CByte(64), CByte(0))
        Label4.Font = New Font("Segoe UI", 11F, FontStyle.Bold)
        Label4.Location = New Point(366, 96)
        Label4.Name = "Label4"
        Label4.Size = New Size(110, 20)
        Label4.TabIndex = 6
        Label4.Text = "ألنسخة الابتدائية"
        ' 
        ' frmLogin
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = Color.FromArgb(CByte(128), CByte(64), CByte(0))
        ClientSize = New Size(800, 450)
        Controls.Add(Label4)
        Controls.Add(Label3)
        Controls.Add(btnLogin)
        Controls.Add(Label2)
        Controls.Add(Label1)
        Controls.Add(txtUser)
        Controls.Add(txtPass)
        Name = "frmLogin"
        Text = "frmLogin"
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents txtPass As TextBox
    Friend WithEvents txtUser As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents btnLogin As Button
    Friend WithEvents Label3 As Label
    Friend WithEvents Label4 As Label
End Class
