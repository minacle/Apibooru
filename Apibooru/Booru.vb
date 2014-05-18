﻿Imports System.Threading.Tasks

Public Class Booru

  Public Property BaseUri As Uri

  Public Sub New(BaseUri As Uri)
    Me.BaseUri = BaseUri
  End Sub

  Public Overridable Function BeginPostsList(Limit As Integer, Page As Integer, Tags As String, Callback As AsyncCallback, State As Object) As IAsyncResult
    Throw New NotImplementedException
  End Function

  Public Overridable Function EndPostsList(AsyncResult As IAsyncResult) As Post()
    Throw New NotImplementedException
  End Function

  Private Class PostsListAsyncState
    Public Property Limit As Integer
    Public Property Page As Integer
    Public Property Tags As String
  End Class

  Public Overridable Function PostsListAsync(Limit As Integer, Page As Integer, Tags As String) As Task(Of Post())
    Return Task.Run(Function() Task(Of Post()).Factory.FromAsync(BeginPostsList(Limit, Page, Tags, Nothing, Nothing), AddressOf EndPostsList, Nothing))
  End Function
End Class