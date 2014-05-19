Imports System.IO
Imports System.Xml

Public MustInherit Class Post

  Protected _Origin As IO.Stream
  Protected _Id As Integer?
  Protected _CreatorId As Integer?
  Protected _Width As Integer?
  Protected _Height As Integer?
  Protected _FileUrl As String
  Protected _Md5 As String
  Protected _Tags As String
  Protected _Source As String
  Protected _Rating As Char?
  Protected _HasChildren As Boolean?
  Protected _ParentId As Integer?
  Protected _Score As Integer?

  Public Overridable ReadOnly Property Id As Integer?
    Get
      Return _Id
    End Get
  End Property

  Public Overridable ReadOnly Property CreatorId As Integer?
    Get
      Return _CreatorId
    End Get
  End Property

  Public Overridable ReadOnly Property Width As Integer?
    Get
      Return _Width
    End Get
  End Property

  Public Overridable ReadOnly Property Height As Integer?
    Get
      Return _Height
    End Get
  End Property

  Public Overridable ReadOnly Property FileUrl As String
    Get
      Return _FileUrl
    End Get
  End Property

  Public Overridable ReadOnly Property Md5 As String
    Get
      Return _Md5
    End Get
  End Property

  Public Overridable ReadOnly Property Tags As String
    Get
      Return _Tags
    End Get
  End Property

  Public Overridable ReadOnly Property Source As String
    Get
      Return _Source
    End Get
  End Property

  Public Overridable ReadOnly Property Rating As Char?
    Get
      Return _Rating
    End Get
  End Property

  Public Overridable ReadOnly Property HasChildren As Boolean?
    Get
      Return _HasChildren
    End Get
  End Property

  Public Overridable ReadOnly Property ParentId As Integer?
    Get
      Return _ParentId
    End Get
  End Property

  Public Overridable ReadOnly Property Score As Integer?
    Get
      Return _Score
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
