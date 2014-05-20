Imports System.Globalization.CultureInfo
Imports System.Net
Imports System.Xml

Public Class Gelbooru
  Inherits Booru

  Private m_Req As WebRequest
  Private m_Res As WebResponse
  Private m_Stream As IO.Stream
  Private m_IsWorking As Boolean
  Private m_IsFinished As Boolean

  Public Sub New(baseUri As String)
    MyBase.New(baseUri)
  End Sub

  Public Sub New(baseUri As Uri)
    MyBase.New(BaseUri)
  End Sub

  Public Overrides Function BeginPostsList(limit As Integer, page As Integer, tags As String, callback As AsyncCallback, state As Object) As IAsyncResult
    Dim q As String = "&"
    If limit >= 0 Then q &= String.Format(InvariantCulture, "limit={0}&", limit)
    If page >= 0 Then q &= String.Format(InvariantCulture, "page={0}&", page)
    If tags IsNot Nothing Then q &= String.Format(InvariantCulture, "tags={0}&", Uri.EscapeDataString(tags))
    q = q.Remove(q.Length - 1)
    Dim u As New Uri(BaseUri, "/index.php?page=dapi&s=post" & q)
    If m_IsWorking Then Throw New InvalidOperationException
    m_IsWorking = True
    m_Req = WebRequest.Create(u)
    Return m_Req.BeginGetResponse(callback, state)
  End Function

  Public Overrides Function EndPostsList(asyncResult As IAsyncResult) As Post()
    If m_IsFinished Then Throw New InvalidOperationException
    m_Res = m_Req.EndGetResponse(asyncResult)
    m_Stream = m_Res.GetResponseStream
    EndPostsList = ParsePostsList(m_Stream)
    m_Stream.Dispose()
    m_Res = Nothing
    m_Req = Nothing
    m_IsFinished = True
    m_IsWorking = False
  End Function

  Private Shared Function ParsePostsList(stream As IO.Stream) As Post()
    Dim posts As New List(Of Post)
    Using reader = XmlReader.Create(stream)
      With reader
        Do While .Read
          Select Case .NodeType
            Case XmlNodeType.Element
              Select Case .Name
                Case "post"
                  posts.Add(New GelbooruPost(.ReadOuterXml))
              End Select
          End Select
        Loop
      End With
    End Using
    Return posts.ToArray
  End Function
End Class
