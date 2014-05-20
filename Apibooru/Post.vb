Imports System.IO
Imports System.Xml

Public MustInherit Class Post
  Implements IDisposable

#Region "IDisposable Support"
  Private disposedValue As Boolean

  Protected Overridable Sub Dispose(disposing As Boolean)
    If Not Me.disposedValue Then
      If disposing Then
        Origin.Dispose()
      End If
    End If
    Me.disposedValue = True
  End Sub

  Public Sub Dispose() Implements IDisposable.Dispose
    Dispose(True)
    GC.SuppressFinalize(Me)
  End Sub
#End Region

  Private m_Origin As IO.Stream

  Protected Property Origin As IO.Stream
    Get
      Return m_Origin
    End Get
    Set(value As IO.Stream)
      m_Origin = value
      CopyToOrigin(m_Origin)
      ParseOrigin()
    End Set
  End Property

  Public Overridable Property Id As Integer?
  Public Overridable Property CreatorId As Integer?
  Public Overridable Property Width As Integer?
  Public Overridable Property Height As Integer?
  Public Overridable Property FileUrl As String
  Public Overridable Property MD5 As String
  Public Overridable Property Tags As String
  Public Overridable Property Source As String
  Public Overridable Property Rating As Char?
  Public Overridable Property HasChildren As Boolean?
  Public Overridable Property ParentId As Integer?
  Public Overridable Property Score As Integer?

  Private Sub CopyToOrigin(stream As Stream)
    Dim origin As New MemoryStream
    stream.CopyTo(origin)
    origin.Seek(0, SeekOrigin.Begin)
    Me.Origin = origin
  End Sub

  Protected MustOverride Sub ParseOrigin()
End Class
