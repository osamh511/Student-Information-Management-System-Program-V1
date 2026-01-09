Imports Microsoft.Data.SqlClient ' المكتبة الضرورية للتعامل مع SQL Server   +  استدعاء الاتصال من App.config
Imports System.Collections.Generic
' استيراد النطاقات الخاصة بمشروعك 
Imports Student_Management_Initial.Student_Management_Initial.Modul
Imports Student_Management_Initial.Student_Management_Initial.Interface
Imports Student_Management_Initial.Student_Management_Initial.Interface.DLL_Interface
Imports Student_Management_Initial.Student_Management_Initial.BLL.Concrete_States
Imports System.Configuration 'استدعاء الاتصال من App.config
Namespace Student_Management_Initial.DLL
    Public Class StudentRepositorySql
        Implements IStudentRepository
        ' استبدل ServerName باسم الخادم لديك (غالباً يكون . أو localhost أو اسم جهازك)
        ' تعريف سلسلة الاتصال في مكان مركزي داخل الكلاس 
        ' التعديل هنا: وضعنا اسم السيرفر الخاص بك بدلاً من النقطة
        ' ملاحظة: في VB.NET نكتب العلامة \ كما هي داخل النص

        'VB.NET يتواصل مع SQL Server، وهذا اسمه ADO.NET. كود يقوم بــ
        '''1️⃣ المثال الأول: ثابت داخل الكود
        '''        ❌ هذا يعني أن الاتصال مكتوب مباشرة داخل الكود.
        '''العيب: إذا أردت تغيير السيرفر أو قاعدة البيانات، يجب إعادة بناء البرنامج.
        'النتيجة: غير مرن، غير مناسب للإنتاج.
        Private Const ConnString As String = "Server=OSAMH51\SQLDEV;Database=StudentDB;Trusted_Connection=True;TrustServerCertificate=True;"

        'مـــــــــــــــــــــلاحظة 
        'اذى اردنا نقل المشرؤع من LocalDB الى SQL Server كامل يجب علينا فتح الملف 
        'الي اسمة اذى اردنا استخدام قاعدة بيانات من نوعSQL Server كامل الموجود على جهازي في المسار "D:\اعمال فيجوال بيسسك\learn_to osamh\program sum\مجلد الحلول الخاصة بي\Student_Management_Initial\توثيق التعلم\أنواع الاتصال بقاعدة البيانات في VB.NET بنائن على البرنامج"

        'كذالك مــــلاحظة 
        '''2️⃣ المثال الثاني: قراءة من App.config عبر Constructor
        '''        ✅ هذا هو الأسلوب الأفضل.
        '''الفائدة: المستودع يقرأ الاتصال من App.config  عند إنشائه.
        '''المرونة: يمكن تغيير الاتصال بدون تعديل الكود، فقط عبر تعديل App.config..
        '''النتيجة: مناسب للإنتاج، احترافي.



        'Private ReadOnly ConnString As String
        'استخدام ConfigurationManager بدلًا من القيم الصلبة
        '    Public Sub New()
        '        ConnString = ConfigurationManager.ConnectionStrings("StudentDB").ConnectionString
        '    End Sub


        '''        3️⃣ المثال الثالث: متغير محلي يقرأ من App.config
        '''                مثال LocalDB
        '''بدل كتابة الاتصال بشكل صلب داخل الكود، نضعه في App.config  ونقرأه عبر ConfigurationManager.
        '''            ✅ أيضًا صحيح، لكنه يقرأ الاتصال في مكان واحد فقط (مثلاً داخل دالة).
        '''الفائدة: سريع وسهل.
        '''العيب: إذا كررت هذا في أكثر من دالة، ستكرر نفس السطر.
        '''النتيجة: جيد، لكن الأفضل أن يكون في مستوى الكلاس (كما في المثال الثاني).
        ' باقي الدوال Register, GetAllStudents, Update, Delete تستخدم ConnString


        'بحيث ConfigurationManager هو كلاس يقراء الاعدادات من ملف APP.config
        'Dim ConnString As String = ConfigurationManager.ConnectionStrings("StudentDB").ConnectionString  ' جلب الإعدادات من ملف App.config

        '        .آلية الإضافة(Register)
        '     CurrentState   وتحويل الحالة
        'في عملية الحفظ، يقوم المستودع بمهمة "تحويل" البيانات من كائن برمجي إلى سجل في قاعدة البيانات:
        '• يتم استخراج مسمى الحالة نصياً عبر خاصية s.CurrentState.StatusName لتخزينها في عمود StudentStatus.
        '• تستخدم الدالة كتلة Using لضمان إغلاق الاتصال تلقائياً، مع معالجة الأخطاء عبر Try...Catch للتنبيه في حال فشل الاتصال [15، 16].

        ' 🔹 إضافة طالب جديد باستخدام Stored Procedure
        Public Sub Register(ByVal s As Student) Implements IStudentRepository.Register ' إنشاء وإدخال طالب جديد
            Try
                '        Using conn As New SqlConnection(ConnString)        ماذا يفعل؟               

                'يتأكد أن السيرفر موجود (OSAMH51\SQLDEV).
                'يتأكد أن قاعدة البيانات موجودة (StudentDB).
                'يستخدم Windows Authentication للدخول.
                'يفتح خط اتصال يسمح بتنفيذ الأوامر.
                'بدون SqlConnection؟
                'لا يمكن تنفيذ أي عملية على قاعدة البيانات.
                'Using   =   يغلق الاتصال تلقائيًا.

                Using conn As New SqlConnection(ConnString) 'توفير القناة التي سيمر عبرها
                    'Dim query As String = "INSERT INTO Students (StudentID, StudentName, StudentStatus) VALUES (@ID, @Name, @Status)"
                    '''2️⃣ SqlCommand
                    '''وظيفته:
                    '''  تنفيذ أوامر SQL مثل:  " INSERT  SELECT   UPDATE  DELETE"

                    '''                    ماذا يفعل؟
                    '''يحمل نص الاستعلام.
                    '''يعرف نوع العملية (إضافة – قراءة – تعديل – حذف).
                    '''يرسل الأمر إلى SQL Server عبر SqlConnection.
                    '''' 1. نضع اسم الإجراء المخزن بدلاً من استعلام SQL
                    'هاذى الطريقة لما نريد الاستعلام من الفيجوال 
                    'Dim cmd As New SqlCommand(query, conn)
                    'مــــــــــــــــلاحظة مهمة
                    'نجاحك في استخدام الإجراء المخزن (Stored Procedure)
                    'هاذى الطريقة لما نريد الاستعلام من داخل قاعدة البياناتSQLServer

                    'تعريف الأمر: يتم إنشاء كائن SqlCommand وتمرير اسم الإجراء المخزن بدلاً من نص الاستعلام (مثل:  "sp_RegisterStudent")
                    Dim cmd As New SqlCommand("sp_RegisterStudent", conn) ' دعم Stored Procedures (مثل sp_RegisterStudent و sp_CheckLogin).
                    ' 2. يجب إخبار الكوماند أننا نستخدم Stored Procedure وليس نصاً عادياً
                    cmd.CommandType = CommandType.StoredProcedure ' تحديد النوع: يجب إخبار البرنامج صراحةً أن نوع الأمر هو إجراء مخزن عبر السطر
                    '''3️⃣ SqlParameter
                    '''🔥 وظيفته
                    '''تمرير البيانات إلى الاستعلام بشكل آمن.

                    '''                    لماذا نستخدمه؟
                    '''يمنع هجمات SQL Injection.
                    '''يجعل الاستعلامات أسرع وأكثر أمانًا.
                    '''يفصل بين نص الاستعلام و البيانات.
                    '''بدون SqlParameter؟
                    'قد يتعرض برنامجك للاختراق أو الأخطاء.
                    cmd.Parameters.AddWithValue("@ID", s.ID)
                    cmd.Parameters.AddWithValue("@Name", s.Name)
                    cmd.Parameters.AddWithValue("@Status", s.CurrentState.StatusName)

                    conn.Open()
                    '' كود تنفيذ العملية (مثل فتح الاتصال وتنفيذ الاستعلام)
                    cmd.ExecuteNonQuery() 'ينفذ العملية داخل SQL Server.
                    MsgBox("تم الحفظ بنجاح باستخدام الإجراء المخزن!")
                End Using
            Catch ex As SqlException
                ' إضافة رسالة تنبيه في حال وجود خطأ في الاتصال
                MsgBox("فشل الاتصال بقاعدة البيانات: " & ex.Message)
            End Try
        End Sub
        ' 🔹 تحديث بيانات الطالب
        Public Sub Update(student As Student) Implements IStudentRepository.Update
            Using conn As New SqlConnection(ConnString)
                Dim query As String =
            "UPDATE Students 
             SET StudentName = @Name, StudentStatus = @Status
             WHERE StudentID = @ID"

                Dim cmd As New SqlCommand(query, conn)
                cmd.Parameters.AddWithValue("@ID", student.ID)
                cmd.Parameters.AddWithValue("@Name", student.Name)
                cmd.Parameters.AddWithValue("@Status", student.CurrentState.StatusName)

                conn.Open()
                'cmd.ExecuteNonQuery() ' هاذى قبلما نفكر بااستخدام Logging + Exception Handling
                Try
                    cmd.ExecuteNonQuery() '' كود تنفيذ العملية (مثل فتح الاتصال وتنفيذ الاستعلام)
                Catch ex As Exception
                    'عند كتابة Throw New AppException(message, ex)
                    '، فإننا نغلف الخطأ الجديد بالقديم (ex) حتى يتمكن كلاس Logger
                    'من تسجيل التفاصيل التقنية الدقيقة في ملف الـ Log لاحقاً 
                    Throw New AppException("فشل تحديث بيانات الطالب", ex) 'إطلاق استثناء مخصص (Throw) وتمرير الخطأ الأصلي كـ
                End Try

            End Using
        End Sub
        Public Sub Delete(studentId As Integer) Implements IStudentRepository.Delete
            Using conn As New SqlConnection(ConnString)
                Dim query As String =
            "DELETE FROM Students WHERE StudentID = @ID"

                Dim cmd As New SqlCommand(query, conn)
                cmd.Parameters.AddWithValue("@ID", studentId)

                conn.Open()
                cmd.ExecuteNonQuery()
            End Using
        End Sub
        ' 🔹 التحقق من تسجيل الدخول
        Public Function ValidateLogin(username As String, password As String) As Boolean Implements IStudentRepository.ValidateLogin
            Using conn As New SqlConnection(ConnString)
                Dim cmd As New SqlCommand("sp_CheckLogin", conn) ' دعم Stored Procedures (مثل sp_RegisterStudent و sp_CheckLogin).
                cmd.CommandType = CommandType.StoredProcedure
                cmd.Parameters.AddWithValue("@User", username)
                cmd.Parameters.AddWithValue("@Pass", password)

                conn.Open()
                Dim count As Integer = CInt(cmd.ExecuteScalar()) ' جلب رقم واحد (0 أو 1)
                Return count > 0
            End Using
        End Function
        ' 🔹 جلب جميع الطلاب
        '''        .آلية الجلب(GetAllStudents)
        '''        وإعادة بناء الكائنات
        '''تعتبر هذه العملية الأكثر ذكاءً في المستودع، حيث يقوم بـ "إعادة إحياء" الكائنات من البيانات النصية:
        '''• عند قراءة البيانات عبر SqlDataReader وتحويل قيمة العمود StudentStatus إلى نص، يستخدم المستودع منطقاً شرطياً (If...Else) لتحديد نوع كائن الحالة الذي يجب إنشاؤه (NewStudentState أو GraduatedState).
        '''• بعد ذلك، يتم استدعاء المنشئ (Constructor) لكلاس الطالب لإعادة بناء الكائن بالكامل وحقنه بالحالة الصحيحة، ثم إضافته للقائمة النهائية
        '''        'الدالة GetAllStudents تستخدم ADO.NET للوصول إلى SQL Server وتنفيذ استعلام Select.
        Public Function GetAllStudents() As List(Of Student) Implements IStudentRepository.GetAllStudents ' قراءة الطلاب إلى قائمة
            '1️⃣ إنشاء قائمة لتجميع الطلاب
            '                هنا نجهّز قائمة فارغة سيتم ملؤها بالطلاب الذين سنجلبهم من SQL Server.
            'ملاحظـــة
            'هنا يتم تخزين الكائنات البرمجية الاتية من قاعدة البيانات الخامSQLServer الى 
            'الى كائنانات برمجية حية من اجل استخدامها في شاشة العرض
            Dim studentsList As New List(Of Student) '1️⃣ إنشاء قائمة لتجميع الطلاب
            '''2️⃣ فتح اتصال مع SQL Server
            '''                ما الذي يحدث هنا؟
            '''SqlConnection = قناة اتصال بين VB.NET و SQL Server.
            '''ConnString = يحتوي اسم السيرفر + اسم قاعدة البيانات + طريقة الدخول.
            '''لماذا نستخدم Using؟
            '''لأن Using يضمن
            '''فتح الاتصال عند البداية.
            '''إغلاق الاتصال تلقائيًا حتى لو حدث خطأ.
            Try
                Using conn As New SqlConnection(ConnString)
                    '3️⃣ تجهيز استعلام SQL
                    '                    هذا استعلام SQL Server حقيقي، وليس ADO.NET.
                    'لكن ADO.NET هو الذي سينفّذه.
                    Dim query As String = "SELECT StudentID, StudentName, StudentStatus FROM Students" '3️⃣ تجهيز استعلام SQL
                    '''4️⃣ إنشاء SqlCommand
                    '''ما دوره؟
                    '''يحمل نص الاستعلام.
                    '''يعرف أنه سيتم تنفيذه على الاتصال conn.
                    '''هو الذي يرسل الاستعلام إلى SQL Server.
                    Dim cmd As New SqlCommand(query, conn)

                    conn.Open() '5️⃣ فتح الاتصال يعني بدون هاذى السطر لايمكن تنفيذ اي استعلام 
                    '6️⃣ تنفيذ الاستعلام باستخدام SqlDataReader
                    '                    ما هو SqlDataReader؟
                    'أداة لقراءة الصفوف Row by Row.
                    'سريع جدًا.
                    'يقرأ البيانات بشكل متسلسل (Forward Only).
                    Using reader = cmd.ExecuteReader()
                        '7️⃣ قراءة كل صف من قاعدة البيانات
                        'كل دورة في While تمثل صفًا واحدًا من جدول Students.
                        While reader.Read()
                            '8️⃣ استخراج البيانات من الأعمدة
                            'هنا نقرأ قيمة العمود StudentStatus.
                            Dim statusText As String = reader("StudentStatus").ToString()

                            Dim state As IStudentState
                            '9️⃣ تحويل النص إلى حالة (State Pattern)
                            'لماذا هذا ؟
                            'لأنك تربط البيانات القادمة من SQL Server بنم ط State Pattern
                            If statusText = "مستجد" Then
                                state = New NewStudentState()
                            Else
                                state = New GraduatedState()
                            End If
                            '                            🔟 إنشاء كائن طالب
                            'هنا يتم
                            'تحويل البيانات الخام من SQL Server
                            'إلى كائن Student كامل
                            'مرتبط بحالة(state)
                            Dim student As New Student(CInt(reader("StudentID")), reader("StudentName").ToString(), state) '    🔟 إنشاء كائن طالب
                            studentsList.Add(student) '1️1️ إضافة الطالب إلى القائمة
                        End While
                    End Using
                End Using
            Catch ex As SqlException
                MsgBox("فشل جلب البيانات: " & ex.Message)
            End Try

            Return studentsList ' 1️2️إرجاع القائمة
        End Function
    End Class
End Namespace

