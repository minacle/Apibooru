Imports System.IO
Imports System.Xml

Public MustInherit Class Post

  Protected _Id As Integer
  Protected _Origin As IO.Stream
  Protected _Width As Integer
  Protected _Height As Integer
  Protected _FileUrl As String

  Public ReadOnly Property Width As Integer
    Get
      Return _Width
    End Get
  End Property

  Public ReadOnly Property Height As Integer
    Get
      Return _Height
    End Get
  End Property

  Public ReadOnly Property FileUrl As String
    Get
      Return _FileUrl
    End Get
  End Property

  Public Sub New([String] As String)
    CopyToOrigin([String])
    ParseOrigin()
  End Sub

  Public Sub New(Stream As Stream)
    CopyToOrigin(Stream)
    ParseOrigin()
  End Sub

  Public Sub New(XmlReader As XmlReader)
    XmlReader.MoveToContent()
    CopyToOrigin(XmlReader.ReadOuterXml)
    ParseOrigin()
  End Sub

  Protected Sub CopyToOrigin([String] As String)
    _Origin = New MemoryStream
    Dim Writer As New StreamWriter(_Origin)
    Writer.Write([String])
    Writer.Flush()
    _Origin.Seek(0, SeekOrigin.Begin)
  End Sub

  Protected Sub CopyToOrigin(Stream As Stream)
    _Origin = New MemoryStream
    Stream.CopyTo(_Origin)
    _Origin.Seek(0, SeekOrigin.Begin)
  End Sub

  Protected MustOverride Sub ParseOrigin()
End Class
