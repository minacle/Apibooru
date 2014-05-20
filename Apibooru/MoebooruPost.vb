Imports System.IO
Imports System.Xml

Public Class MoebooruPost
  Inherits Post

  Public Overridable Property CreatedAt As Integer
  Public Overridable Property Author As String
  Public Overridable Property Change As Integer
  Public Overridable Property FileSize As Integer
  Public Overridable Property IsShownInIndex As Boolean
  Public Overridable Property PreviewUrl As String
  Public Overridable Property PreviewWidth As Integer
  Public Overridable Property PreviewHeight As Integer
  Public Overridable Property ActualPreviewWidth As Integer
  Public Overridable Property ActualPreviewHeight As Integer
  Public Overridable Property SampleUrl As String
  Public Overridable Property SampleWidth As Integer
  Public Overridable Property SampleHeight As Integer
  Public Overridable Property SampleFileSize As Integer
  Public Overridable Property JpegUrl As String
  Public Overridable Property JpegWidth As String
  Public Overridable Property JpegHeight As Integer
  Public Overridable Property JpegFileSize As Integer
  Public Overridable Property Status As String
  Public Overridable Property IsHeld As Boolean

  Public Sub New([string] As String)
    Dim origin As New MemoryStream
    Dim writer As New StreamWriter(origin)
    writer.Write([string])
    writer.Flush()
    origin.Seek(0, SeekOrigin.Begin)
    Me.Origin = origin
  End Sub

  Public Sub New(stream As Stream)
    Origin = stream
  End Sub

  Protected Overrides Sub ParseOrigin()
    Using Reader = XmlReader.Create(Origin)
      With Reader
        Do While .Read
          Select Case .NodeType
            Case XmlNodeType.Element
              Select Case .Name
                Case "post"
                  ActualPreviewHeight = .GetAttribute("actual_preview_height")
                  ActualPreviewWidth = .GetAttribute("actual_preview_width")
                  Author = .GetAttribute("author")
                  Change = .GetAttribute("change")
                  CreatedAt = .GetAttribute("created_at")
                  CreatorId = .GetAttribute("creator_id")
                  FileSize = .GetAttribute("file_size")
                  FileUrl = .GetAttribute("file_url")
                  HasChildren = .GetAttribute("has_children")
                  Height = .GetAttribute("height")
                  Id = .GetAttribute("id")
                  IsHeld = .GetAttribute("is_held")
                  IsShownInIndex = .GetAttribute("is_shown_in_index")
                  JpegFileSize = .GetAttribute("jpeg_file_size")
                  JpegHeight = .GetAttribute("jpeg_height")
                  JpegUrl = .GetAttribute("jpeg_url")
                  MD5 = .GetAttribute("md5")
                  ParentId = .GetAttribute("parentid")
                  PreviewHeight = .GetAttribute("preview_height")
                  PreviewUrl = .GetAttribute("preview_url")
                  Rating = .GetAttribute("rating")
                  SampleFileSize = .GetAttribute("sample_file_size")
                  SampleHeight = .GetAttribute("sample_height")
                  SampleUrl = .GetAttribute("sample_url")
                  SampleWidth = .GetAttribute("sample_width")
                  Score = .GetAttribute("score")
                  Source = .GetAttribute("source")
                  Status = .GetAttribute("status")
                  Tags = .GetAttribute("tags")
                  Width = .GetAttribute("width")
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
    Origin.Seek(0, SeekOrigin.Begin)
  End Sub
End Class
