' 3. كلاس الطالب (The Model)
Imports Student_Management_Initial.Student_Management_Initial.Interface
'1. مفهوم "علاقة الاحتواء" (Has-A Relationship)
'بدلاً من استخدام الوراثة التقليدية، يعتمد كلاس الطالب على التركيب؛ أي أن كائن الطالب "يحتوي" بداخله على كائن آخر يمثل حالته [1، 3]. يظهر هذا برمجياً في كلاس Student من خلال تعريف خاصية: Public Property CurrentState As IStudentState.هذا الربط هو ما تصفه المصادر بـ "بناء الكيان عبر التركيب" لربط الطالب بالحالة
'2. الربط عبر المنشئ (Constructor Binding)
'تشير المصادر إلى أن عملية "التركيب" لا تترك للصدفة، بل يتم إجبارها عند "ولادة" الكائن برمجياً.
'• يحتوي كلاس الطالب على Constructor (Sub New) يستقبل كائن الحالة كمعامل أساسي.
'• هذا يضمن اتساق النموذج (Model Consistency)؛ حيث يستحيل إنشاء كائن طالب في الذاكرة دون أن يكون "مركباً" مع حالة معينة، مما يحمي البرنامج من أخطاء المراجع الفارغة (Null Reference).
'3. التركيب كبديل للجمل الشرطية
'الهدف الجوهري من استخدام التركيب هنا هو تحويل الطالب إلى كائن يعرف حالته بنفسه دون استخدام جمل If معقدة.
'بسبب وجود كائن الحالة
'(CurrentState) "مركباً" داخل الطالب، يمكن للنظام استدعاء s.CurrentState.StatusName مباشرة

Namespace Student_Management_Initial.Modul

    Public Class Student
        Public Property ID As Integer
        Public Property Name As String
        Public Property CurrentState As IStudentState 'المفهوم المطبق: "التركيب بدلاً من الوراثة" (Composition over Inheritance).

        ' استخدام Constructor لضمان وجود حالة ابتدائية
        'يؤدي منشئ الكائن (Constructor) في كلاس الطالب (Student) دور "حارس البوابة" لضمان سلامة البيانات وصحة منطق الأعمال منذ اللحظة الأولى لإنشاء الكائن في الذاكرة

        ' وظيفت المنشى هاذى :
        'المصادر تشير إلى أن ما قمت بتطبيقه يسمى "التركيب عبر المنشئ" (Constructor Binding) لربط الطالب بحالته، وليس لتقييد عدد النسخ 
        Public Sub New(ByVal id As Integer, ByVal name As String, ByVal state As IStudentState)
            Me.ID = id
            Me.Name = name
            Me.CurrentState = state
            'هذا الهيكل يضمن أن خاصية
            'CurrentState ستكون محقونة دائماً بكائن حالة حقيقي
            'عند قيام المستخدم بحفظ بيانات طالب جديد (عبر حدث btnSave_Click) يتم استدعاء هذا المنشئ لإنشاء الكائن. في هذه المرحلة، يتم حقن حالة "NewStudentState" كمعامل ثالث بشكل افتراضي، مما يربط الطالب الجديد بحالة "مستجد" فور إنشائه
        End Sub
    End Class
End Namespace

