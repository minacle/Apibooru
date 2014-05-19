Imports System.IO
Imports System.Xml

Public Class MoebooruPost
  Inherits Post

  Protected _CreatedAt As Integer
  Protected _Author As String
  Protected _Change As Integer
  Protected _FileSize As Integer
  Protected _IsShownInIndex As Boolean
  Protected _PreviewUrl As String
  Protected _PreviewWidth As Integer
  Protected _PreviewHeight As Integer
  Protected _ActualPreviewWidth As Integer
  Protected _ActualPreviewHeight As Integer
  Protected _SampleUrl As String
  Protected _SampleWidth As Integer
  Protected _SampleHeight As Integer
  Protected _SampleFileSize As Integer
  Protected _JpegUrl As String
  Protected _JpegWidth As Integer
  Protected _JpegHeight As Integer
  Protected _JpegFileSize As Integer
  Protected _Status As String
  Protected _IsHeld As Boolean

  Public Overridable ReadOnly Property CreatedAt As Integer
    Get
      Return _CreatedAt
    End Get
  End Property

  Public Overridable ReadOnly Property Author As String
    Get
      Return _Author
    End Get
  End Property

  Public Overridable ReadOnly Property Change As Integer
    Get
      Return _Change
    End Get
  End Property

  Public Overridable ReadOnly Property FileSize As Integer
    Get
      Return _FileSize
    End Get
  End Property

  Public Overridable ReadOnly Property IsShownInIndex As Boolean
    Get
      Return _IsShownInIndex
    End Get
  End Property

  Public Overridable ReadOnly Property PreviewUrl As String
    Get
      Return _PreviewUrl
    End Get
  End Property

  Public Overridable ReadOnly Property PreviewWidth As Integer
    Get
      Return _PreviewWidth
    End Get
  End Property

  Public Overridable ReadOnly Property PreviewHeight As Integer
    Get
      Return _PreviewHeight
    End Get
  End Property

  Public Overridable ReadOnly Property ActualPreviewWidth As Integer
    Get
      Return _ActualPreviewWidth
    End Get
  End Property

  Public Overridable ReadOnly Property ActualPreviewHeight As Integer
    Get
      Return _ActualPreviewHeight
    End Get
  End Property

  Public Overridable ReadOnly Property SampleUrl As String
    Get
      Return _SampleUrl
    End Get
  End Property

  Public Overridable ReadOnly Property SampleWidth As Integer
    Get
      Return _SampleWidth
    End Get
  End Property

  Public Overridable ReadOnly Property SampleHeight As Integer
    Get
      Return _SampleHeight
    End Get
  End Property

  Public Overridable ReadOnly Property SampleFileSize As Integer
    Get
      Return _SampleFileSize
    End Get
  End Property

  Public Overridable ReadOnly Property JpegUrl As String
    Get
      Return _JpegUrl
    End Get
  End Property

  Public Overridable ReadOnly Property JpegWidth As String
    Get
      Return _JpegWidth
    End Get
  End Property

  Public Overridable ReadOnly Property JpegHeight As Integer
    Get
      Return _JpegHeight
    End Get
  End Property

  Public Overridable ReadOnly Property JpegFileSize As Integer
    Get
      Return _JpegFileSize
    End Get
  End Property

  Public Overridable ReadOnly Property Status As String
    Get
      Return _Status
    End Get
  End Property

  Public Overridable ReadOnly Property IsHeld As Boolean
    Get
      Return _IsHeld
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
    Using Reader = XmlReader.Create(_Origin)
      With Reader
        Do While .Read
          Select Case .NodeType
            Case XmlNodeType.Element
              Select Case .Name
                Case "post"
                  _ActualPreviewHeight = .GetAttribute("actual_preview_height")
                  _ActualPreviewWidth = .GetAttribute("actual_preview_width")
                  _Author = .GetAttribute("author")
                  _Change = .GetAttribute("change")
                  _CreatedAt = .GetAttribute("created_at")
                  _CreatorId = .GetAttribute("creator_id")
                  _FileSize = .GetAttribute("file_size")
                  _FileUrl = .GetAttribute("file_url")
                  _HasChildren = .GetAttribute("has_children")
                  _Height = .GetAttribute("height")
                  _Id = .GetAttribute("id")
                  _IsHeld = .GetAttribute("is_held")
                  _IsShownInIndex = .GetAttribute("is_shown_in_index")
                  _JpegFileSize = .GetAttribute("jpeg_file_size")
                  _JpegHeight = .GetAttribute("jpeg_height")
                  _JpegUrl = .GetAttribute("jpeg_url")
                  _Md5 = .GetAttribute("md5")
                  _ParentId = .GetAttribute("parentid")
                  _PreviewHeight = .GetAttribute("preview_height")
                  _PreviewUrl = .GetAttribute("preview_url")
                  _Rating = .GetAttribute("rating")
                  _SampleFileSize = .GetAttribute("sample_file_size")
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
