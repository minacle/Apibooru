Imports System.IO
Imports System.Xml

Public Class GelbooruPost
  Inherits Post

  Protected _Tags As String
  Protected _CreatedAt As String
  Protected _CreatorId As Integer
  Protected _Change As Integer
  Protected _Source As String
  Protected _Score As Integer
  Protected _Md5 As String
  Protected _PreviewUrl As String
  Protected _PreviewWidth As Integer
  Protected _PreviewHeight As Integer
  Protected _SampleUrl As String
  Protected _SampleWidth As Integer
  Protected _SampleHeight As Integer
  Protected _Rating As Char
  Protected _HasChildren As Boolean
  Protected _ParentId As Integer?
  Protected _Status As String
  Protected _HasNotes As Boolean
  Protected _HasComments As Boolean

  Public ReadOnly Property Tags As String
    Get
      Return _Tags
    End Get
  End Property

  Public ReadOnly Property CreatedAt As Integer
    Get
      Return _CreatedAt
    End Get
  End Property

  Public ReadOnly Property CreatorId As Integer
    Get
      Return _CreatorId
    End Get
  End Property

  Public ReadOnly Property Change As Integer
    Get
      Return _Change
    End Get
  End Property

  Public ReadOnly Property Source As String
    Get
      Return _Source
    End Get
  End Property

  Public ReadOnly Property Score As Integer
    Get
      Return _Score
    End Get
  End Property

  Public ReadOnly Property Md5 As String
    Get
      Return _Md5
    End Get
  End Property

  Public ReadOnly Property PreviewUrl As String
    Get
      Return _PreviewUrl
    End Get
  End Property

  Public ReadOnly Property PreviewWidth As Integer
    Get
      Return _PreviewWidth
    End Get
  End Property

  Public ReadOnly Property PreviewHeight As Integer
    Get
      Return _PreviewHeight
    End Get
  End Property

  Public ReadOnly Property SampleUrl As String
    Get
      Return _SampleUrl
    End Get
  End Property

  Public ReadOnly Property SampleWidth As Integer
    Get
      Return _SampleWidth
    End Get
  End Property

  Public ReadOnly Property SampleHeight As Integer
    Get
      Return _SampleHeight
    End Get
  End Property

  Public ReadOnly Property Rating As Char
    Get
      Return _Rating
    End Get
  End Property

  Public ReadOnly Property HasChildren As Boolean
    Get
      Return _HasChildren
    End Get
  End Property

  Public ReadOnly Property ParentId As Integer?
    Get
      Return _ParentId
    End Get
  End Property

  Public ReadOnly Property Status As String
    Get
      Return _Status
    End Get
  End Property

  Public ReadOnly Property HasNotes As Boolean
    Get
      Return _HasNotes
    End Get
  End Property

  Public ReadOnly Property HasComments As Boolean
    Get
      Return _HasComments
    End Get
  End Property

  Public Sub New([String] As String)
    MyBase.New([String])
  End Sub

  Public Sub New(Stream As Stream)
    MyBase.New(Stream)
  End Sub

  Public Sub New(XmlReader As Xml.XmlReader)
    MyBase.New(XmlReader)
  End Sub

  Protected Overrides Sub ParseOrigin()
    Dim ReaderSettings As New XmlReaderSettings With {.ConformanceLevel = ConformanceLevel.Fragment, .DtdProcessing = DtdProcessing.Ignore}
    Using Reader = XmlReader.Create(_Origin)
      With Reader
        Do While .Read
          Select Case .NodeType
            Case XmlNodeType.Element
              Select Case .Name
                Case "post"
                  _Change = .GetAttribute("change")
                  _CreatedAt = .GetAttribute("created_at")
                  _CreatorId = .GetAttribute("creator_id")
                  _FileUrl = .GetAttribute("file_url")
                  _HasChildren = .GetAttribute("has_children")
                  _HasComments = .GetAttribute("has_comments")
                  _HasNotes = .GetAttribute("has_notes")
                  _Height = .GetAttribute("height")
                  _Id = .GetAttribute("id")
                  _Md5 = .GetAttribute("md5")
                  _ParentId = .GetAttribute("parentid")
                  _PreviewHeight = .GetAttribute("preview_height")
                  _PreviewUrl = .GetAttribute("preview_url")
                  _Rating = .GetAttribute("rating")
                  _SampleHeight = .GetAttribute("sample_height")
                  _SampleUrl = .GetAttribute("sample_url")
                  _SampleWidth = .GetAttribute("sample_width")
                  _Score = .GetAttribute("score")
                  _Source = .GetAttribute("source")
                  _Status = .GetAttribute("status")
                  _Tags = .GetAttribute("tags")
                  _Width = .GetAttribute("width")
                  If .IsEmptyElement Then Exit Do
              End Select
            Case XmlNodeType.EndElement
              Select Case .Name
                Case "post"
                  Exit Do
              End Select
          End Select
        Loop
      End With
    End Using
    _Origin.Seek(0, SeekOrigin.Begin)
  End Sub
End Class
