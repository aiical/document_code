Attribute VB_Name = "defs"
Option Explicit

'���㳤��,����Ӣ��
Public Function StrLen(Expression As Variant) As Long
    Dim i As Long
    For i = 1 To Len(Expression)
        If Asc(Mid(Expression, i, 1)) < 0 Then
            StrLen = StrLen + 2
        Else
            StrLen = StrLen + 1
        End If
    Next
End Function
