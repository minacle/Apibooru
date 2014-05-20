Imports System.Threading.Tasks

Public Class Booru

  Public Property BaseUri As Uri

  Public Sub New(baseUri As String)
    Me.BaseUri = New Uri(baseUri)
  End Sub

  Public Sub New(baseUri As Uri)
    Me.BaseUri = baseUri
  End Sub

  Public Overridable Function BeginPostsList(callback As AsyncCallback, state As Object, Optional limit As Integer = -1, Optional page As Integer = -1, Optional tags As String = Nothing) As IAsyncResult
    Return BeginPostsList(limit, page, tags, callback, state)
  End Function

  Public Overridable Function BeginPostsList(limit As Integer, page As Integer, tags As String, callback As AsyncCallback, state As Object) As IAsyncResult
    Throw New NotImplementedException
  End Function

  Public Overridable Function EndPostsList(asyncResult As IAsyncResult) As Post()
    Throw New NotImplementedException
  End Function

  Public Overridable Function PostsListAsync(limit As Integer, page As Integer, tags As String) As Task(Of Post())
    Return Task.Run(Function() Task(Of Post()).Factory.FromAsync(BeginPostsList(limit, page, tags, Nothing, Nothing), AddressOf EndPostsList, Nothing))
  End Function
End Class
