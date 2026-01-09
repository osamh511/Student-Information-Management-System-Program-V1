'' تنفيذ المستودع باستخدام القوائم الديناميكية
'Imports Student_Management_Initial.Student_Management_Initial.Interface.DLL_Interface
'Imports Student_Management_Initial.Student_Management_Initial.Modul
'Imports Student_Management_Initial.Student_Management_Initial.Interface.DLL_Interface
'Imports Student_Management_Initial.Student_Management_Initial.Modul
'Imports Student_Management_Initial.Student_Management_Initial.Interface.DLL_Interface

'Namespace Student_Management_Initial.DLL
'    Public Class StudentRepository
'        Implements IStudentRepository
' هنا تكمن الكبسولة، القائمة مخفية عن الفورم
'        Private _db As New List(Of Student)
'' المصدر [13، 63]: هذه هي البوابة الوحيدة المسموح بالمرور منها
'تشير المصادر إلى أن هذه الدالة تمثل نقطة "الإرسال" (Dispatch)؛ حيث تستقبل كائن الطالب المكتمل من واجهة المستخدم وتتولى مسؤولية حفظه 
'• تطبيق التجريد (Abstraction): يتم تعريفها في واجهة IStudentRepository لضمان أن أي مستودع (سواء كان قائمة أو SQL) سيوفر نفس الوظيفة بنفس الاسم والمعاملات [
'• تحقيق الكبسولة (Encapsulation): في مستودع القائمة، تعتبر هذه الدالة هي "المنفذ الوحيد" للوصول إلى القائمة الخاصة _db وإضافة البيانات إليها، مما يمنع واجهة المستخدم من التلاعب المباشر بالمخزن 
'        Public Sub Register(ByVal s As Student) Implements IStudentRepository.Register
'            _db.Add(s)'' الإضافة تتم داخلياً بعيداً عن أعين الفورم
'        End Sub

'Public Sub Update(student As Student) Implements IStudentRepository.Update
'    Dim existing = _db.FirstOrDefault(Function(s) s.ID = student.ID)

'    If existing Is Nothing Then
'        Throw New Exception("الطالب غير موجود")
'    End If

'    existing.Name = student.Name
'    existing.CurrentState = student.CurrentState
'End Sub


'Public Sub Delete(studentId As Integer) Implements IStudentRepository.Delete
'    Dim student = _db.FirstOrDefault(Function(s) s.ID = studentId)

'    If student Is Nothing Then
'        Throw New Exception("الطالب غير موجود")
'    End If

'    _db.Remove(student)
'End Sub


'في هذا المستودع، يتم توفير البيانات عبر دالة GetAllStudents التي تعيد القائمة كاملة. هذه الدالة هي المحرك الأساسي لعملية الربط والعرض؛ حيث تُسحب القائمة من المستودع لتخضع لعملية الفلترة عبر LINQ قبل عرضها في الجدول (DataGridView) [6، 25].
'        Public Function GetAllStudents() As List(Of Student) Implements IStudentRepository.GetAllStudents
'            Return _db
'        End Function
'    End Class
'End Namespace

