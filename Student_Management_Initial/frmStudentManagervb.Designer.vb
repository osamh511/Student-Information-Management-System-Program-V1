<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmStudentManagervb
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        btnSave = New Button()
        btnSave2 = New Button()
        btnUpdate = New Button()
        txtID = New TextBox()
        txtName = New TextBox()
        TextBox3 = New TextBox()
        TextBox4 = New TextBox()
        dgvMain = New DataGridView()
        btnDelete = New Button()
        btnLoad = New Button()
        Label1 = New Label()
        Label2 = New Label()
        Label3 = New Label()
        CType(dgvMain, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' btnSave
        ' 
        btnSave.Location = New Point(350, 150)
        btnSave.Name = "btnSave"
        btnSave.Size = New Size(75, 23)
        btnSave.TabIndex = 0
        btnSave.Text = "btnSave"
        btnSave.UseVisualStyleBackColor = True
        ' 
        ' btnSave2
        ' 
        btnSave2.Location = New Point(256, 194)
        btnSave2.Name = "btnSave2"
        btnSave2.Size = New Size(105, 23)
        btnSave2.TabIndex = 1
        btnSave2.Text = "2btnSave"
        btnSave2.UseVisualStyleBackColor = True
        ' 
        ' btnUpdate
        ' 
        btnUpdate.Location = New Point(367, 194)
        btnUpdate.Name = "btnUpdate"
        btnUpdate.Size = New Size(75, 23)
        btnUpdate.TabIndex = 2
        btnUpdate.Text = "btnUpdate"
        btnUpdate.UseVisualStyleBackColor = True
        ' 
        ' txtID
        ' 
        txtID.Location = New Point(325, 26)
        txtID.Name = "txtID"
        txtID.Size = New Size(100, 23)
        txtID.TabIndex = 3
        ' 
        ' txtName
        ' 
        txtName.Location = New Point(325, 73)
        txtName.Name = "txtName"
        txtName.Size = New Size(100, 23)
        txtName.TabIndex = 4
        ' 
        ' TextBox3
        ' 
        TextBox3.Location = New Point(681, 76)
        TextBox3.Name = "TextBox3"
        TextBox3.Size = New Size(100, 23)
        TextBox3.TabIndex = 5
        ' 
        ' TextBox4
        ' 
        TextBox4.Location = New Point(681, 140)
        TextBox4.Name = "TextBox4"
        TextBox4.Size = New Size(100, 23)
        TextBox4.TabIndex = 6
        ' 
        ' dgvMain
        ' 
        dgvMain.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        dgvMain.Location = New Point(0, 256)
        dgvMain.Name = "dgvMain"
        dgvMain.Size = New Size(804, 203)
        dgvMain.TabIndex = 7
        ' 
        ' btnDelete
        ' 
        btnDelete.Location = New Point(464, 194)
        btnDelete.Name = "btnDelete"
        btnDelete.Size = New Size(75, 23)
        btnDelete.TabIndex = 8
        btnDelete.Text = "btnDelete"
        btnDelete.UseVisualStyleBackColor = True
        ' 
        ' btnLoad
        ' 
        btnLoad.Location = New Point(681, 180)
        btnLoad.Name = "btnLoad"
        btnLoad.Size = New Size(107, 37)
        btnLoad.TabIndex = 9
        btnLoad.Text = "btnLoad"
        btnLoad.UseVisualStyleBackColor = True
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Location = New Point(464, 29)
        Label1.Name = "Label1"
        Label1.Size = New Size(18, 15)
        Label1.TabIndex = 10
        Label1.Text = "ID"
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.Location = New Point(453, 76)
        Label2.Name = "Label2"
        Label2.Size = New Size(41, 15)
        Label2.TabIndex = 11
        Label2.Text = "NAME"
        ' 
        ' Label3
        ' 
        Label3.AutoSize = True
        Label3.Location = New Point(618, 34)
        Label3.Name = "Label3"
        Label3.Size = New Size(170, 15)
        Label3.TabIndex = 12
        Label3.Text = "راح يتم تفعيلها في النسخة القادمة"
        ' 
        ' frmStudentManagervb
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = Color.FromArgb(CByte(192), CByte(255), CByte(255))
        ClientSize = New Size(800, 450)
        Controls.Add(Label3)
        Controls.Add(Label2)
        Controls.Add(Label1)
        Controls.Add(btnLoad)
        Controls.Add(btnDelete)
        Controls.Add(dgvMain)
        Controls.Add(TextBox4)
        Controls.Add(TextBox3)
        Controls.Add(txtName)
        Controls.Add(txtID)
        Controls.Add(btnUpdate)
        Controls.Add(btnSave2)
        Controls.Add(btnSave)
        Name = "frmStudentManagervb"
        Text = "Form1"
        CType(dgvMain, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents btnSave As Button
    Friend WithEvents btnSave2 As Button
    Friend WithEvents btnUpdate As Button
    Friend WithEvents txtID As TextBox
    Friend WithEvents txtName As TextBox
    Friend WithEvents TextBox3 As TextBox
    Friend WithEvents TextBox4 As TextBox
    Friend WithEvents dgvMain As DataGridView
    Friend WithEvents btnDelete As Button
    Friend WithEvents btnLoad As Button
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
End Class
