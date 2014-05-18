Imports System.Threading.Tasks
Imports System.Net
Imports System.Xml

Public Class Gelbooru
  Inherits Booru

  Private _Req As WebRequest
  Private _Res As WebResponse
  Private _Stream As IO.Stream
  Private _IsWorking As Boolean
  Private _IsFinished As Boolean

  Public Sub New(BaseUri As Uri)
    MyBase.New(BaseUri)
  End Sub

  Public Overrides Function BeginPostsList(Limit As Integer, Page As Integer, Tags As String, Callback As AsyncCallback, State As Object) As IAsyncResult
    Dim U As New Uri(BaseUri, String.Format("/index.php?page=dapi&s=post&q=index&limit={0}&pid={1}&tags={2}", Limit, Page, Tags))
    If _IsWorking Then Throw New InvalidOperationException
    _IsWorking = True
    _Req = WebRequest.Create(U)
    Return _Req.BeginGetResponse(Callback, State)
  End Function

  Public Overrides Function EndPostsList(AsyncResult As IAsyncResult) As Post()
    If _IsFinished Then Throw New InvalidOperationException
    _Res = _Req.EndGetResponse(AsyncResult)
    _Stream = _Res.GetResponseStream
    EndPostsList = ParsePostsList(_Stream)
    _Stream.Dispose()
    _Res = Nothing
    _Req = Nothing
    _IsFinished = True
    _IsWorking = False
  End Function

  Private Function ParsePostsList(Stream As IO.Stream) As Post()
    Dim Posts As New List(Of Post)
    Using Reader = XmlReader.Create(Stream)
      With Reader
        Do While .Read
          Select Case .NodeType
            Case XmlNodeType.Element
              Select Case .Name
                Case "post"
                  Posts.Add(New GelbooruPost(.ReadOuterXml))
              End Select
          End Select
        Loop
      End With
    End Using
    Return Posts.ToArray
  End Function
End Class
