Imports System.IO
Imports System.Xml

Public Class DanbooruPost
  Inherits Post

  Public Overridable Property CreatedAt As String
  Public Overridable Property LastCommentBumpedAt As String
  Public Overridable Property IsNoteLocked As Boolean
  Public Overridable Property FavCount As Integer
  Public Overridable Property FileExt As String
  Public Overridable Property LastNotedAt As String
  Public Overridable Property IsRatingLocked As Boolean
  Public Overridable Property ApproverId As Integer?
  Public Overridable Property TagCountGeneral As Integer
  Public Overridable Property TagCountArtist As Integer
  Public Overridable Property TagCountCharacter As Integer
  Public Overridable Property TagCountCopyright As Integer
  Public Overridable Property FileSize As Integer
  Public Overridable Property IsStatusLocked As Boolean
  Public Overridable Property FavString As String
  Public Overridable Property PoolString As String
  Public Overridable Property UpScore As Integer
  Public Overridable Property DownScore As Integer
  Public Overridable Property IsPending As Boolean
  Public Overridable Property IsFlagged As Boolean
  Public Overridable Property IsDeleted As Boolean
  Public Overridable Property TagCount As Integer
  Public Overridable Property UpdatedAt As String
  Public Overridable Property IsBanned As Boolean
  Public Overridable Property PixivId As Integer?
  Public Overridable Property LastCommentedAt As String
  Public Overridable Property UploaderName As String
  Public Overridable Property HasLarge As Boolean
  Public Overridable Property TagStringArtist As String
  Public Overridable Property TagStringCharacter As String
  Public Overridable Property TagStringCopyright As String
  Public Overridable Property TagStringGeneral As String
  Public Overridable Property LargeFileUrl As String
  Public Overridable Property PreviewFileUrl As String

  Public Overridable Property UploaderId As Integer
    Get
      Return CreatorId
    End Get
    Set(value As Integer)
      CreatorId = value
    End Set
  End Property

  Public Overridable Property ImageWidth As Integer
    Get
      Return Width
    End Get
    Set(value As Integer)
      Width = value
    End Set
  End Property

  Public Overridable Property ImageHeight As Integer
    Get
      Return Height
    End Get
    Set(value As Integer)
      Height = value
    End Set
  End Property

  Public Overridable Property TagString As String
    Get
      Return Tags
    End Get
    Set(value As String)
      Tags = value
    End Set
  End Property

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
                  If .IsEmptyElement Then Exit Do
                  Do While .Read
                    Select Case .NodeType
                      Case XmlNodeType.Element
                        If .IsEmptyElement Then Continue Do
                        Dim Name = .Name
                        .Read()
                        If .NodeType = XmlNodeType.EndElement Then Continue Do
                        Select Case Name
                          Case "id"
                            Id = .Value
                          Case "created-at"
                            CreatedAt = .Value
                          Case "uploader-id"
                            CreatorId = .Value
                          Case "score"
                            Score = .Value
                          Case "source"
                            Source = .Value
                          Case "md5"
                            MD5 = .Value
                          Case "last-comment-bumped-at"
                            LastCommentBumpedAt = .Value
                          Case "rating"
                            Rating = .Value
                          Case "image-width"
                            Width = .Value
                          Case "image-height"
                            Height = .Value
                          Case "tag-string"
                            Tags = .Value
                          Case "is-note-locked"
                            IsNoteLocked = .Value
                          Case "fav-count"
                            FavCount = .Value
                          Case "file-ext"
                            FileExt = .Value
                          Case "last-noted-at"
                            LastNotedAt = .Value
                          Case "is-rating-locked"
                            IsRatingLocked = .Value
                          Case "parent-id"
                            ParentId = .Value
                          Case "has-children"
                            HasChildren = .Value
                          Case "approver-id"
                            ApproverId = .Value
                          Case "tag-count-general"
                            TagCountGeneral = .Value
                          Case "tag-count-artist"
                            TagCountArtist = .Value
                          Case "tag-count-character"
                            TagCountCharacter = .Value
                          Case "tag-count-copyright"
                            TagCountCopyright = .Value
                          Case "file-size"
                            FileSize = .Value
                          Case "is-status-locked"
                            IsStatusLocked = .Value
                          Case "fav-string"
                            FavString = .Value
                          Case "pool-string"
                            PoolString = .Value
                          Case "up-score"
                            UpScore = .Value
                          Case "down-score"
                            DownScore = .Value
                          Case "is-pending"
                            IsPending = .Value
                          Case "is-flagged"
                            IsFlagged = .Value
                          Case "is-deleted"
                            IsDeleted = .Value
                          Case "tag-count"
                            TagCount = .Value
                          Case "updated-at"
                            UpdatedAt = .Value
                          Case "is-banned"
                            IsBanned = .Value
                          Case "pixiv-id"
                            PixivId = .Value
                          Case "last-commented-at"
                            LastCommentedAt = .Value
                          Case "uploader-name"
                            UploaderName = .Value
                          Case "has-large"
                            HasLarge = .Value
                          Case "tag-string-artist"
                            TagStringArtist = .Value
                          Case "tag-string-character"
                            TagStringCharacter = .Value
                          Case "tag-string-copyright"
                            TagStringCopyright = .Value
                          Case "tag-string-general"
                            TagStringGeneral = .Value
                          Case "file-url"
                            FileUrl = .Value
                          Case "large-file-url"
                            LargeFileUrl = .Value
                          Case "preview-file-url"
                            PreviewFileUrl = .Value
                        End Select
                        .Read()
                      Case XmlNodeType.EndElement
                        Select Case .Name
                          Case "post"
                            Exit Do
                        End Select
                    End Select
                  Loop
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
