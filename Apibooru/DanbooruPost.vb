Imports System.IO
Imports System.Xml

Public Class DanbooruPost
  Inherits Post

  Protected _CreatedAt As String
  Protected _LastCommentBumpedAt As String
  Protected _IsNoteLocked As Boolean
  Protected _FavCount As Integer
  Protected _FileExt As String
  Protected _LastNotedAt As String
  Protected _IsRatingLocked As Boolean
  Protected _ApproverId As Integer?
  Protected _TagCountGeneral As Integer
  Protected _TagCountArtist As Integer
  Protected _TagCountCharacter As Integer
  Protected _TagCountCopyright As Integer
  Protected _FileSize As Integer
  Protected _IsStatusLocked As Boolean
  Protected _FavString As String
  Protected _PoolString As String
  Protected _UpScore As Integer
  Protected _DownScore As Integer
  Protected _IsPending As Boolean
  Protected _IsFlagged As Boolean
  Protected _IsDeleted As Boolean
  Protected _TagCount As Integer
  Protected _UpdatedAt As String
  Protected _IsBanned As Boolean
  Protected _PixivId As Integer?
  Protected _LastCommentedAt As String
  Protected _UploaderName As String
  Protected _HasLarge As Boolean
  Protected _TagStringArtist As String
  Protected _TagStringCharacter As String
  Protected _TagStringCopyright As String
  Protected _TagStringGeneral As String
  Protected _LargeFileUrl As String
  Protected _PreviewFileUrl As String

  Public Overridable ReadOnly Property CreatedAt As String
    Get
      Return _CreatedAt
    End Get
  End Property

  Public Overridable ReadOnly Property UploaderId As Integer
    Get
      Return _CreatorId
    End Get
  End Property

  Public Overridable ReadOnly Property LastCommentBumpedAt As String
    Get
      Return _LastCommentBumpedAt
    End Get
  End Property

  Public Overridable ReadOnly Property ImageWidth As Integer
    Get
      Return _Width
    End Get
  End Property

  Public Overridable ReadOnly Property ImageHeight As Integer
    Get
      Return _Height
    End Get
  End Property

  Public Overridable ReadOnly Property TagString As String
    Get
      Return _Tags
    End Get
  End Property

  Public Overridable ReadOnly Property IsNoteLocked As Boolean
    Get
      Return _IsNoteLocked
    End Get
  End Property

  Public Overridable ReadOnly Property FavCount As Integer
    Get
      Return _FavCount
    End Get
  End Property

  Public Overridable ReadOnly Property FileExt As String
    Get
      Return _FileExt
    End Get
  End Property

  Public Overridable ReadOnly Property LastNotedAt As String
    Get
      Return _LastNotedAt
    End Get
  End Property

  Public Overridable ReadOnly Property IsRatingLocked As Boolean
    Get
      Return _IsRatingLocked
    End Get
  End Property

  Public Overridable ReadOnly Property ApproverId As Integer?
    Get
      Return _ApproverId
    End Get
  End Property

  Public Overridable ReadOnly Property TagCountGeneral As Integer
    Get
      Return _TagCountGeneral
    End Get
  End Property

  Public Overridable ReadOnly Property TagCountArtist As Integer
    Get
      Return _TagCountArtist
    End Get
  End Property

  Public Overridable ReadOnly Property TagCountCharacter As Integer
    Get
      Return _TagCountCharacter
    End Get
  End Property

  Public Overridable ReadOnly Property TagCountCopyright As Integer
    Get
      Return _TagCountCopyright
    End Get
  End Property

  Public Overridable ReadOnly Property FileSize As Integer
    Get
      Return _FileSize
    End Get
  End Property

  Public Overridable ReadOnly Property IsStatusLocked As Boolean
    Get
      Return _IsStatusLocked
    End Get
  End Property

  Public Overridable ReadOnly Property FavString As String
    Get
      Return _FavString
    End Get
  End Property

  Public Overridable ReadOnly Property PoolString As String
    Get
      Return _PoolString
    End Get
  End Property

  Public Overridable ReadOnly Property UpScore As Integer
    Get
      Return _UpScore
    End Get
  End Property

  Public Overridable ReadOnly Property DownScore As Integer
    Get
      Return _DownScore
    End Get
  End Property

  Public Overridable ReadOnly Property IsPending As Boolean
    Get
      Return _IsPending
    End Get
  End Property

  Public Overridable ReadOnly Property IsFlagged As Boolean
    Get
      Return _IsFlagged
    End Get
  End Property

  Public Overridable ReadOnly Property IsDeleted As Boolean
    Get
      Return _IsDeleted
    End Get
  End Property

  Public Overridable ReadOnly Property TagCount As Integer
    Get
      Return _TagCount
    End Get
  End Property

  Public Overridable ReadOnly Property UpdatedAt As String
    Get
      Return _UpdatedAt
    End Get
  End Property

  Public Overridable ReadOnly Property IsBanned As Boolean
    Get
      Return _IsBanned
    End Get
  End Property

  Public Overridable ReadOnly Property PixivId As Integer?
    Get
      Return _PixivId
    End Get
  End Property

  Public Overridable ReadOnly Property LastCommentedAt As String
    Get
      Return _LastCommentedAt
    End Get
  End Property

  Public Overridable ReadOnly Property UploaderName As String
    Get
      Return _UploaderName
    End Get
  End Property

  Public Overridable ReadOnly Property HasLarge As Boolean
    Get
      Return _HasLarge
    End Get
  End Property

  Public Overridable ReadOnly Property TagStringArtist As String
    Get
      Return _TagStringArtist
    End Get
  End Property

  Public Overridable ReadOnly Property TagStringCharacter As String
    Get
      Return _TagStringCharacter
    End Get
  End Property

  Public Overridable ReadOnly Property TagStringCopyright As String
    Get
      Return _TagStringCopyright
    End Get
  End Property

  Public Overridable ReadOnly Property TagStringGeneral As String
    Get
      Return _TagStringGeneral
    End Get
  End Property

  Public Overridable ReadOnly Property LargeFileUrl As String
    Get
      Return _LargeFileUrl
    End Get
  End Property

  Public Overridable ReadOnly Property PreviewFileUrl As String
    Get
      Return _PreviewFileUrl
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
                            _Id = .Value
                          Case "created-at"
                            _CreatedAt = .Value
                          Case "uploader-id"
                            _CreatorId = .Value
                          Case "score"
                            _Score = .Value
                          Case "source"
                            _Source = .Value
                          Case "md5"
                            _Md5 = .Value
                          Case "last-comment-bumped-at"
                            _LastCommentBumpedAt = .Value
                          Case "rating"
                            _Rating = .Value
                          Case "image-width"
                            _Width = .Value
                          Case "image-height"
                            _Height = .Value
                          Case "tag-string"
                            _Tags = .Value
                          Case "is-note-locked"
                            _IsNoteLocked = .Value
                          Case "fav-count"
                            _FavCount = .Value
                          Case "file-ext"
                            _FileExt = .Value
                          Case "last-noted-at"
                            _LastNotedAt = .Value
                          Case "is-rating-locked"
                            _IsRatingLocked = .Value
                          Case "parent-id"
                            _ParentId = .Value
                          Case "has-children"
                            _HasChildren = .Value
                          Case "approver-id"
                            _ApproverId = .Value
                          Case "tag-count-general"
                            _TagCountGeneral = .Value
                          Case "tag-count-artist"
                            _TagCountArtist = .Value
                          Case "tag-count-character"
                            _TagCountCharacter = .Value
                          Case "tag-count-copyright"
                            _TagCountCopyright = .Value
                          Case "file-size"
                            _FileSize = .Value
                          Case "is-status-locked"
                            _IsStatusLocked = .Value
                          Case "fav-string"
                            _FavString = .Value
                          Case "pool-string"
                            _PoolString = .Value
                          Case "up-score"
                            _UpScore = .Value
                          Case "down-score"
                            _DownScore = .Value
                          Case "is-pending"
                            _IsPending = .Value
                          Case "is-flagged"
                            _IsFlagged = .Value
                          Case "is-deleted"
                            _IsDeleted = .Value
                          Case "tag-count"
                            _TagCount = .Value
                          Case "updated-at"
                            _UpdatedAt = .Value
                          Case "is-banned"
                            _IsBanned = .Value
                          Case "pixiv-id"
                            _PixivId = .Value
                          Case "last-commented-at"
                            _LastCommentedAt = .Value
                          Case "uploader-name"
                            _UploaderName = .Value
                          Case "has-large"
                            _HasLarge = .Value
                          Case "tag-string-artist"
                            _TagStringArtist = .Value
                          Case "tag-string-character"
                            _TagStringCharacter = .Value
                          Case "tag-string-copyright"
                            _TagStringCopyright = .Value
                          Case "tag-string-general"
                            _TagStringGeneral = .Value
                          Case "file-url"
                            _FileUrl = .Value
                          Case "large-file-url"
                            _LargeFileUrl = .Value
                          Case "preview-file-url"
                            _PreviewFileUrl = .Value
                        End Select
                        .Read()
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
    _Origin.Seek(0, SeekOrigin.Begin)
  End Sub
End Class
