Imports System.IO
Imports System.Xml

Public Class GelbooruPost
  Inherits Post

  Public Overridable Property TagString As String
  Public Overridable Property CreatedAt As Integer
  Public Overridable Property Change As Integer
  Public Overridable Property PreviewUrl As String
  Public Overridable Property PreviewWidth As Integer
  Public Overridable Property PreviewHeight As Integer
  Public Overridable Property SampleUrl As String
  Public Overridable Property SampleWidth As Integer
  Public Overridable Property SampleHeight As Integer
  Public Overridable Property Status As String
  Public Overridable Property HasNotes As Boolean
  Public Overridable Property HasComments As Boolean

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
                  Change = .GetAttribute("change")
                  CreatedAt = .GetAttribute("created_at")
                  CreatorId = .GetAttribute("creator_id")
                  FileUrl = .GetAttribute("file_url")
                  HasChildren = .GetAttribute("has_children")
                  HasComments = .GetAttribute("has_comments")
                  HasNotes = .GetAttribute("has_notes")
                  Height = .GetAttribute("height")
                  Id = .GetAttribute("id")
                  MD5 = .GetAttribute("md5")
                  ParentId = .GetAttribute("parentid")
                  PreviewHeight = .GetAttribute("preview_height")
                  PreviewUrl = .GetAttribute("preview_url")
                  Rating = .GetAttribute("rating")
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
