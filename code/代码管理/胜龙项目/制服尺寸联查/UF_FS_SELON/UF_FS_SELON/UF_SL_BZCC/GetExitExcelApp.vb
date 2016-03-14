Module GetExitExcelApp




    Public xlapp As Object 'Excel对象  
    Public xlbook As Object '工作簿  
    Public xlsheet As Object '工作表  

    Declare Function FindWindow Lib "user32" Alias _
 "FindWindowA" (ByVal lpClassName As String, _
 ByVal lpWindowName As Long) As Long
    Declare Function SendMessage Lib "user32" Alias "SendMessageA" (ByVal hwnd As Long, ByVal wMsg As Long, ByVal wParam As Long, ByVal lParam As IntPtr) As Long


    '杀EXCEL进程
    Public Sub KillExcel()
        On Error GoTo Errmessages  '在做系统操作时加排错标签是个好习惯

        Dim TargetName As String = "Excel" '存储进程名为文本型，注：进程名不加扩展名
        Dim TargetKill() As Process = Process.GetProcessesByName(TargetName) '从进程名获取进程
        Dim TargetPath As String  '存储进程路径为文本型
        If TargetKill.Length > 1 Then  '判断进程名的数量，如果同名进程数量在2个以上，用For循环关闭进程。
            For i = 0 To TargetKill.Length - 1
                TargetPath = TargetKill(i).MainModule.FileName
                TargetKill(i).Kill()
            Next
        ElseIf TargetKill.Length = 0 Then  '判断进程名的数量，没有发现进程直接弹窗。不需要的，可直接删掉该If子句
            MsgBox("没有发现进程！")
            Exit Sub
        ElseIf TargetKill.Length = 1 Then  '判断进程名的数量，如果只有一个，就不用For循环
            TargetKill(0).Kill()
        End If

        'MsgBox("已终止" & TargetKill.Length & "个进程") '弹窗提示已终止多少个进程

Errmessages:  '定义排错标签
        If Err.Description <> Nothing Then  '判断有无错误，如果有，则 ↓
            MsgBox(Err.Description) '当出现错误时，弹窗提示
        End If

    End Sub


    Function GetExcel() As Object
        'Dim MyXL As Object  '用于存放Microsoft Excel 引用的变量。  
        Dim ExcelWasNotRunning As Boolean '用于最后释放的标记。  
        On Error Resume Next  '延迟错误捕获。  
        '不带第一个参数调用 Getobject 函数将返回对该应用程序的实例的引用。  
        '如果该应用程序不在运行，则会产生错误。  
        GetExcel = GetObject(, "Excel.Application")
        If Err.Number <> 0 Then ExcelWasNotRunning = True
        Err.Clear() '如果发生错误则要清除 Err 对象。  
        '检测 Microsoft Excel。如果 Microsoft Excel 在运行，则将其加入运行对象表。  
        DetectExcel() '该过程检测并登记正在运行的 Excel  
        '设置其 Application 属性，显示 Microsoft Excel。  
        '然后使用 MyXL 对象引用的 Windows 集合,显示包含该文件的实际窗口。  
        GetExcel.Application.Visible = False
        GetExcel.Parent.Windows(1).Visible = False
        '如果在启动时，Microsoft Excel 的这份副本不在运行中，  
        '则使用 Application 属性的 Quit 方法来关闭它。  
        '注意，当试图退出 Microsoft Excel 时，  
        '标题栏会闪烁，并显示一条消息询问是否保存所加载的文件。  
        If ExcelWasNotRunning = True Then
            GetExcel.Application.Quit()
        End If
        'MyXL = Nothing  '释放对该应用程序和电子数据表的引用。  
    End Function

    '该过程检测并登记正在运行的 Excel。  
    Sub DetectExcel()
        Const WM_USER = 1024
        Dim hwnd As Long
        '如果 Excel 在运行，则该 API 调用将返回其句柄。  
        hwnd = FindWindow("XLMAIN", 0)
        If hwnd = 0 Then  '0 表示没有 Excel 在运行。  
            Exit Sub
        Else
            'Excel 在运行，因此可以使用 SendMessage API'函数将其放入运行对象表。  
            SendMessage(hwnd, WM_USER + 18, 0, 0)
        End If
    End Sub


End Module
