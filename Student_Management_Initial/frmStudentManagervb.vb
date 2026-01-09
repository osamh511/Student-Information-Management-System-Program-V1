
Imports System.Linq
Imports Student_Management_Initial.Student_Management_Initial.BLL
Imports Student_Management_Initial.Student_Management_Initial.BLL.Concrete_States
Imports Student_Management_Initial.Student_Management_Initial.DLL
Imports Student_Management_Initial.Student_Management_Initial.Interface.DLL_Interface
Imports Student_Management_Initial.Student_Management_Initial.Modul

'الية عمل الفورم
'شبيه لتقريب المفهوم (من المصادر): تخيل أن "الفورم" هو جراح، وIStudentRepository هو مشرط العمليات. الجراح لا يصنع المشرط بنفسه (لا ينشئ المستودع داخلياً)، بل يقف في غرفة العمليات ويعلن للممرض (النظام): "لن أبدأ العملية حتى تضع في يدي مشرطاً يطابق المواصفات" 
'بحيث الممرض قد يعطيه مشرطاً من الفولاذ (SQL) أو مشرطاً للاختبار (List Repository)، والجراح سيقوم بعمله في الحالتين لأن الأداة "تؤدي الوظيفة" المطلوبة في العقد 
Public Class frmStudentManagervb
    ' مرجع للمستودع (Dependency)
    'هنا الفورم يحجز مكاناً لـ "أداة" دون تحديد نوعها الحقيقي (قائمة أو SQL)
    'لتفسير: كلمة ReadOnly تعني أن الفورم يطلب هذه الأداة مرة واحدة فقط عند "ولادته" ويمنع تغييرها لاحقاً لضمان الثبات
    Private ReadOnly _repo As IStudentRepository 'هاذى هو هذا هو "المخزن الداخلي" للفورم الذي يحافظ على المستودع طوال فترة تشغيل الشاشة.
    Private Sub frmStudentManagervb_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        '        اذا يحدث خلف الكواليس؟
        'عند الضغط على زر تحميل البيانات أو عند فتح الفورم

        '''        UI
        ''' ↓
        '''_repo.GetAllStudents()
        ''' ↓
        '''StudentRepositorySql
        ''' ↓
        '''Select Case From Students
        ''' ↓
        '''تحويل Rows → Objects
        ''' ↓
        '''List(Of Student)
        ''' ↓
        '''Linq Projection
        ''' ↓
        '''dgvMain


        Try
            RefreshGrid()
        Catch ex As Exception
            MsgBox("حدث خطأ أثناء تحميل البيانات: " & ex.Message) 'تظهر البيانات مباشرة من SQL Server
        End Try
    End Sub
    ''' <summary>
    ''' وظيفة RefreshGrid؟
    'وظيفتها الوحيدة:
    'تحويل بيانات الطلاب (كائنات برمجية)
    'إلى بيانات مرئية داخل DataGridView
    '❌ لا تتعامل مع SQL
    '❌ لا تنشئ طلاب
    '❌ لا تحفظ بيانات
    '✔️ فقط عرض البيانات
    ''' </summary>
    Private Sub RefreshGrid()
        ' تأكد من أن _repo.GetAllStudents() تعيد List(Of Student)

        Dim students = _repo.GetAllStudents() ' 1️⃣ جلب جميع الطلاب من المستودع (SQL أو List)

        If students IsNot Nothing Then
            dgvMain.DataSource = Nothing

            ' كتابة الـ Select بشكل صريح لتجنب فشل الاستنتاج (Inference)
            dgvMain.DataSource = students.Select(Function(s As Student) New With {
            .رقم_الطالب = s.ID,
            .الاسم = s.Name,
            .حالة_الطالب = s.CurrentState.StatusName
        }).ToList()
            '            ملخص عقلي
            '            🔹 students = قائمة كائنات Student
            '🔹 Select = مرّ على كل كائن
            '🔹 s = طالب واحد من القائمة
            '🔹 s.ID = خاصية من الكائن
            '🔹 الناتج = كائن عرض جديد
        End If
    End Sub
    'مـــلاحظات
    'بما انحنا عدلنا المنشى الخاص باالفورم بحيث يستقبل مستودع فانة يجب علينا التركيز على ان الفورم ماراح يشتغل الى حينما يتم يتمرير المستودع الية ,وهنا يجب التركيز انة ماراح يشتغل الفورم الى باالمستودع
    ' تطبيق حقن المنشئ (Constructor Injection)
    'بينما تقوم InitializeComponent() ببناء "الجسد" (الأدوات الرسومية)، يقوم سطر Me._repo = repo بوضع "العقل" (مستودع البيانات) داخل هذا الجسد. هذا التكامل هو ما يحول الفورم من مجرد واجهة رسومية صماء إلى نظام احترافي قادر على معالجة البيانات 
    'تفسير: بهذا الكود، أعلن الفورم صراحةً أنه لا يمكن لأي جزء في البرنامج تشغيل هذه الشاشة إلا إذا "أعطاها" مستودعاً جاهزاً كمعامل (Parameter)

    ' الاختلاف بين
    ' Singleton وبينConstructor
    'منشئ الطالب(Constructor): يهدف إلى إنتاج نسخ متعددة (كل طالب هو كائن مستقل)، ولكنه يشترط أن تكون كل نسخة "صالحة" ومكتملة البيانات عند إنشائها
    Public Sub New(ByVal repo As IStudentRepository) ' تعديل "طريقة ولادة" الفورم لتستقبل المعامل (repo)
        InitializeComponent() '' بناء الواجهة أولاً
        Me._repo = repo ' استلام الأداة وتخزينها
    End Sub
    ' عند ضغط زر الحفظ (btnAddObject)
    Private Sub BTnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        ' 1. إنشاء الطالب بحالة "مستجد" افتراضياً
        Dim student = New Student(CInt(txtID.Text), txtName.Text, New NewStudentState())

        ' 2. التخزين عبر الـ DAL
        _repo.Register(student)

        ' 3. التحديث البصري باستخدام LINQ
        RefreshGrid()


    End Sub
    Private Sub btnSave2_Click(sender As Object, e As EventArgs) Handles btnSave2.Click
        ' 1. إنشاء الطالب بحالة "مستجد" افتراضياً
        Dim student2 = New Student(CInt(txtID.Text), txtName.Text, New GraduatedState())

        ' 2. التخزين عبر الـ DAL
        _repo.Register(student2)

        ' 3. التحديث البصري باستخدام LINQ
        RefreshGrid()
    End Sub

    Private Sub btnUpdate_Click_1(sender As Object, e As EventArgs) Handles btnUpdate.Click
        Try
            Dim student = New Student(
            CInt(txtID.Text),
            txtName.Text,
            New GraduatedState()
        )

            StudentValidator.Validate(student)

            _repo.Update(student)

            RefreshGrid()
            'هاذى قبلما نفكر Logging + Exception Handling
            'Catch ex As Exception
            '    MsgBox(ex.Message)
            'End Try
        Catch ex As Exception
            ErrorHandler.Handle(ex)
        End Try
        'الآن:
        '        المستخدم يرى رسالة واضحة
        'الخطأ محفوظ في ملف
        'البرنامج لا ينهار
    End Sub

    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        If dgvMain.CurrentRow Is Nothing Then Return

        Dim id As Integer = CInt(dgvMain.CurrentRow.Cells("رقم_الطالب").Value)

        If MsgBox("هل أنت متأكد من الحذف؟", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
            _repo.Delete(id)
            RefreshGrid()
        End If
    End Sub

End Class