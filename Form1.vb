Imports System.Reflection
Imports System.Drawing.Drawing2D
Imports System.Drawing.Imaging
Imports System.IO
Imports System.Security.Policy
Imports System.Runtime.Intrinsics.X86

'<Assembly: AssemblyTitle("AWSID")>
'<Assembly: AssemblyDescription("")>
'<Assembly: AssemblyCompany("")>
'<Assembly: AssemblyProduct("AWSID")>
'<Assembly: AssemblyCopyright("Copyright ©  2019")>
'<Assembly: AssemblyTrademark("")>



#Disable Warning WFO1000 ' Missing code serialization configuration for property content
Public Class Form1

    Private FilenameLoaded As String, FilesInDirectory As New List(Of String)
    Private Const EXTENSIONS = ".jpg.jpeg.gif.png.bmp"
    Private Const MINIMUMWIDTH As Integer = 600
    Private OriginalImg As Image

    Private Sub ImageLoadRefresh()
        Dim Avail As Rectangle = Screen.GetWorkingArea(Me)
        Dim origHeight As Boolean = False, OrigWidth As Boolean = False
        If Not FullScreen Then
            If OriginalImg.Height < Avail.Height - 200 Then
                Me.Height = OriginalImg.Height + Panel1.Top + StatusStrip1.Height + 50
                origHeight = True
            Else : Me.Height = Avail.Height - 200
            End If
            If OriginalImg.Width < Avail.Width - 200 Then
                Me.Width = OriginalImg.Width + 20
                OrigWidth = True
            Else : Me.Width = Avail.Width - 200
            End If
            If Me.Width < MINIMUMWIDTH Then
                OrigWidth = False : Me.Width = MINIMUMWIDTH
            End If
        End If
        pic.Image = Nothing
        If mnuView_Autosize.Checked Then
            If OrigWidth And origHeight Then pic.SizeMode = PictureBoxSizeMode.Normal Else pic.SizeMode = PictureBoxSizeMode.Zoom
            pic.Dock = DockStyle.Fill
        Else
            pic.Dock = DockStyle.None
            pic.Width = OriginalImg.Width
            pic.Height = OriginalImg.Height
            pic.SizeMode = PictureBoxSizeMode.Normal
        End If
        pic.Image = OriginalImg
        If FilenameLoaded > "" Then lblfilename.Text = Path.GetFileName(FilenameLoaded) Else lblfilename.Text = lblfilename.Tag
    End Sub

    Private Sub ImageLoadFile(fn As String)
        Try
            OriginalImg = Image.FromFile(fn).Clone()
            ImageLoadRefresh()
            FilenameLoaded = fn
        Catch ex As Exception
            MsgBox("Unable to load picture  file " & fn & vbCrLf & vbCrLf & ex.GetType().Name & ": " & ex.Message, MsgBoxStyle.Critical)
            Exit Sub
        End Try
        RefreshNavigations()
    End Sub

    Private Sub RefreshNavigations()
        FilesInDirectory.Clear()
        Dim posOfMyFile As Integer = -1
        If FilenameLoaded > "" Then
            For Each f As FileInfo In New DirectoryInfo(Path.GetDirectoryName(FilenameLoaded)).GetFiles()
                If f.Extension > "" AndAlso EXTENSIONS.Contains(f.Extension.ToLower()) Then FilesInDirectory.Add(f.FullName)
                If f.FullName.Equals(Path.GetFullPath(FilenameLoaded)) Then posOfMyFile = FilesInDirectory.IndexOf(f.FullName)
            Next
            lblFilesInDir.Text = $"{FilesInDirectory.Count} images in directory"
            Me.Text = Path.GetFileName(FilenameLoaded) & " - Simple Image Viewer"
        Else
            lblFilesInDir.Text = lblFilesInDir.Tag
            Me.Text = "Simple Image Viewer"
        End If
        mnuNavigateNext.Enabled = FilesInDirectory.Count > 1 AndAlso posOfMyFile < FilesInDirectory.Count - 1
        mnuNavigatePrev.Enabled = FilesInDirectory.Count > 1 AndAlso posOfMyFile > 0
        If mnuNavigatePrev.Enabled Then mnuNavigatePrev.Tag = FilesInDirectory(posOfMyFile - 1)
        If mnuNavigateNext.Enabled Then mnuNavigateNext.Tag = FilesInDirectory(posOfMyFile + 1)
    End Sub


    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim args() As String = Environment.GetCommandLineArgs()
        If args.Length = 2 AndAlso IO.File.Exists(args(1)) Then ImageLoadFile(args(1))
        pic.AllowDrop = True
        AddHandler mnuExit.Click, Sub() Me.Close()
    End Sub

    Private Sub ToolStripVIEW_DropDownItemClicked(sender As Object, e As ToolStripItemClickedEventArgs) Handles ToolStripVIEW.DropDownItemClicked
        If e.ClickedItem Is mnuView_Autosize Then
            mnuView_Orig.Checked = False
            mnuView_Autosize.Checked = True
        Else
            mnuView_Orig.Checked = True
            mnuView_Autosize.Checked = False
        End If
        ImageLoadRefresh()
    End Sub

    Private Sub mnuOpen_Click(sender As Object, e As EventArgs) Handles mnuOpen.Click
        Dim f As New OpenFileDialog() With {.Filter = "Images|" & EXTENSIONS.Replace(".", ";*.").TrimStart(";") & "|All|*.*", .Multiselect = False}
        If f.ShowDialog() Then ImageLoadFile(f.FileName)
    End Sub

    Private Sub EvemnuNavigateButtons_Click(sender As Object, e As EventArgs) Handles mnuNavigatePrev.Click, mnuNavigateNext.Click
        ImageLoadFile(sender.tag) 'includes a refresh of navigation
    End Sub


    Private Pos1, pos2 As Point, Draw As Boolean = False, penMarker As New Pen(New SolidBrush(Color.Yellow))
    Private Mark As Rectangle = Rectangle.Empty

    Private Sub pic_MouseDown(sender As Object, e As MouseEventArgs) Handles pic.MouseDown
        If e.Button = MouseButtons.Left Then
            Pos1 = e.Location
            If e.X < 5 Then Pos1.X = 0
            If e.Y < 5 Then Pos1.Y = 0
            Mark = Rectangle.Empty
            Draw = True
            pic.Invalidate()
        End If
    End Sub

    Private Sub pic_MouseUp(sender As Object, e As MouseEventArgs) Handles pic.MouseUp
        Draw = False
    End Sub

    Private Sub pic_MouseMove(sender As Object, e As MouseEventArgs) Handles pic.MouseMove
        If Draw And e.Button = MouseButtons.Left Then
            pos2 = e.Location
            Mark = New Rectangle(Pos1, New Size(pos2.X - Pos1.X, pos2.Y - Pos1.Y))
            pic.Invalidate()
        End If
    End Sub

    Private Function GetSelectedImage() As Bitmap
        Dim srcRect As Rectangle
        If pic.SizeMode = PictureBoxSizeMode.Zoom Or pic.SizeMode = PictureBoxSizeMode.StretchImage Then
            Dim ImageRect As Rectangle = pic.GetType().GetMethod("ImageRectangleFromSizeMode", BindingFlags.NonPublic Or BindingFlags.Instance).Invoke(pic, New Object() {pic.SizeMode})
            Dim cx As Double = pic.Image.Width / ImageRect.Width
            Dim cy As Double = pic.Image.Height / ImageRect.Height
            Dim r2 As Rectangle = Rectangle.Intersect(ImageRect, Mark)
            r2.Offset(-ImageRect.X, -ImageRect.Y)
            srcRect = New Rectangle(r2.X * cx, r2.Y * cy, r2.Width * cx, r2.Height * cy)
        Else
            Dim ScaleFactor As Double = pic.Width / pic.Image.Width
            srcRect = New Rectangle(Mark.X / ScaleFactor, Mark.Y / ScaleFactor, Mark.Width / ScaleFactor, Mark.Height / ScaleFactor)
        End If
        Dim dstRect As New Rectangle(0, 0, srcRect.Width, srcRect.Height)
        Dim targetBmp As New Bitmap(dstRect.Width, dstRect.Height)
        Dim gr_dest As Graphics = Graphics.FromImage(targetBmp)
        gr_dest.DrawImage(pic.Image, dstRect, srcRect, GraphicsUnit.Pixel)
        Return targetBmp
    End Function

    Private Sub pic_MouseWheel(sender As Object, e As MouseEventArgs) Handles pic.MouseWheel
        If ModifierKeys.HasFlag(Keys.Control) Then
            If mnuView_Orig.Checked = False Then
                ToolStripVIEW_DropDownItemClicked(Nothing, New ToolStripItemClickedEventArgs(mnuView_Orig))
                Application.DoEvents()
            End If
            Dim scale As Single = If(e.Delta > 0, 1.2, 0.8)
            Dim img As New Bitmap(OriginalImg, New Size(pic.Image.Width * scale, pic.Image.Height * scale))
            pic.Width = img.Width
            pic.Height = img.Height
            pic.Image = img
        Else
            If e.Delta > 0 Then
                If mnuNavigateNext.Enabled Then
                    mnuNavigateNext.PerformClick()
                ElseIf FilesInDirectory.Count > 1 Then
                    ImageLoadFile(FilesInDirectory(0))
                End If
            Else
                If mnuNavigatePrev.Enabled Then
                    mnuNavigatePrev.PerformClick()
                ElseIf FilesInDirectory.Count > 1 Then
                    ImageLoadFile(FilesInDirectory(FilesInDirectory.Count - 1))
                End If
            End If
        End If
    End Sub

    Private Sub pic_Paint(sender As Object, e As PaintEventArgs) Handles pic.Paint
        If Draw Then
            e.Graphics.DrawRectangle(penMarker, Mark)
        End If
    End Sub

    Private Sub Form1_Resize(sender As Object, e As EventArgs) Handles Me.Resize
        If mnuView_Autosize.Checked Then pic.SizeMode = PictureBoxSizeMode.Zoom
    End Sub

    Private Sub Form1_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        If e.Control Then
            If e.KeyCode = Keys.V Then
                mnuPaste.PerformClick()
            ElseIf e.KeyCode = Keys.C Then
                mnuCopy.PerformClick()
            End If
        ElseIf e.KeyCode = Keys.Escape Then
            If FullScreen Then FullScreen = False Else Me.Close()
        End If
    End Sub

    Private Sub mnuCopy_Click(sender As Object, e As EventArgs) Handles mnuCopy.Click
        If Mark.Equals(Rectangle.Empty) Then
            Clipboard.SetImage(OriginalImg)
        Else
            Clipboard.SetImage(GetSelectedImage())
        End If
    End Sub

    Private Sub mnuPaste_Click(sender As Object, e As EventArgs) Handles mnuPaste.Click
        If Clipboard.ContainsImage() Then
            OriginalImg = Clipboard.GetImage()
            ImageLoadRefresh()
            FilenameLoaded = ""
            RefreshNavigations()
        End If
    End Sub

    Private Sub mnuCrop_Click(sender As Object, e As EventArgs) Handles mnuCrop.Click
        If Not Mark.Equals(Rectangle.Empty) Then
            OriginalImg = GetSelectedImage()
            ImageLoadRefresh()
        End If
    End Sub


    Private Sub EvePic_DragEnter(sender As Object, e As DragEventArgs) Handles pic.DragEnter
        If e.Data.GetDataPresent(DataFormats.FileDrop) Then e.Effect = DragDropEffects.Link Else e.Effect = DragDropEffects.None
    End Sub

    Private Sub EvePic_DragDrop(sender As Object, e As DragEventArgs) Handles pic.DragDrop
        If e.Data.GetDataPresent(DataFormats.FileDrop) Then
            Dim filelist() As String = CType(e.Data.GetData(DataFormats.FileDrop), String())
            ImageLoadFile(filelist(0))
        End If
    End Sub

    Private Sub EVEmnuRotate_Click(sender As Object, e As EventArgs) Handles mnuRotateLEFT.Click, mnuRotateRIGHT.Click
        OriginalImg = RotateImage(pic.Image, If(sender Is mnuRotateLEFT, -90, 90), True, False, Color.Transparent)
        ImageLoadRefresh()
    End Sub

    Public Shared Function RotateImage(inputImage As Image, angleDegrees As Single, upsizeOk As Boolean, clipOk As Boolean, backgroundColor As Color) As Bitmap
        ' Test for zero rotation and return a clone of the input image
        If angleDegrees = 0F Then Return CType(inputImage.Clone(), Bitmap)

        ' Set up old and new image dimensions, assuming upsizing not wanted and clipping OK
        Dim oldWidth As Integer = inputImage.Width
        Dim oldHeight As Integer = inputImage.Height
        Dim newWidth = oldWidth
        Dim newHeight = oldHeight
        Dim scaleFactor = 1.0F

        ' If upsizing wanted or clipping not OK calculate the size of the resulting bitmap
        If upsizeOk OrElse Not clipOk Then
            Dim angleRadians = angleDegrees * Math.PI / 180.0R

            Dim cos = Math.Abs(Math.Cos(angleRadians))
            Dim sin = Math.Abs(Math.Sin(angleRadians))
            newWidth = CInt(Math.Round(oldWidth * cos + oldHeight * sin))
            newHeight = CInt(Math.Round(oldWidth * sin + oldHeight * cos))
        End If

        ' If upsizing not wanted and clipping not OK need a scaling factor
        If Not upsizeOk AndAlso Not clipOk Then
            scaleFactor = Math.Min(CSng(oldWidth) / newWidth, CSng(oldHeight) / newHeight)
            newWidth = oldWidth
            newHeight = oldHeight
        End If

        ' Create the new bitmap object. If background color is transparent it must be 32-bit, 
        '  otherwise 24-bit is good enough.
        Dim newBitmap As Bitmap = New Bitmap(newWidth, newHeight, PixelFormat.Format32bppArgb)
        newBitmap.SetResolution(inputImage.HorizontalResolution, inputImage.VerticalResolution)

        ' Create the Graphics object that does the work
        Using graphicsObject As Graphics = Graphics.FromImage(newBitmap)
            graphicsObject.InterpolationMode = InterpolationMode.HighQualityBicubic
            graphicsObject.PixelOffsetMode = PixelOffsetMode.HighQuality
            graphicsObject.SmoothingMode = SmoothingMode.HighQuality

            ' Fill in the specified background color if necessary
            'If backgroundColor IsNot Color.Transparent Then graphicsObject.Clear(backgroundColor)

            ' Set up the built-in transformation matrix to do the rotation and maybe scaling
            graphicsObject.TranslateTransform(newWidth / 2.0F, newHeight / 2.0F)

            If scaleFactor <> 1.0F Then graphicsObject.ScaleTransform(scaleFactor, scaleFactor)

            graphicsObject.RotateTransform(angleDegrees)
            graphicsObject.TranslateTransform(-oldWidth / 2.0F, -oldHeight / 2.0F)

            ' Draw the result 
            graphicsObject.DrawImage(inputImage, 0, 0)
        End Using

        Return newBitmap
    End Function

    Private Sub EvemnuSave_Click(sender As Object, e As EventArgs) Handles mnuSave.Click, mnuSaveAs.Click
        If sender Is mnuSave And FilenameLoaded > "" Then
            OriginalImg.Save(FilenameLoaded)
        Else
            Dim f As New SaveFileDialog() With {.Filter = "Images|" & EXTENSIONS.Replace(".", ";*.").TrimStart(";") & "|All|*.*", .FileName = FilenameLoaded}
            If f.ShowDialog() = DialogResult.OK Then
                OriginalImg.Save(f.FileName)
                ImageLoadFile(f.FileName)
            End If
        End If
    End Sub

    Private Sub mnuDelete_Click(sender As Object, e As EventArgs) Handles mnuDelete.Click
        If FilenameLoaded > "" AndAlso MsgBox($"Delete {Path.GetFileName(FilenameLoaded)}?", MsgBoxStyle.YesNo Or MsgBoxStyle.Question) = MsgBoxResult.Yes Then IO.File.Delete(FilenameLoaded)
    End Sub

    Private Sub mnuFullscreen_Click(sender As Object, e As EventArgs) Handles mnuFullscreen.Click
        FullScreen = Not FullScreen
    End Sub


    Public Property FullScreen As Boolean
        Get
            Return (FormBorderStyle = FormBorderStyle.None)
        End Get
        Set(value As Boolean)
            Static Dim locSave As Point = Me.Location
            If value Then
                locSave = Me.Location
                WindowState = FormWindowState.Normal
                FormBorderStyle = FormBorderStyle.None
                Me.Location = Point.Empty
                Me.Size = Screen.GetWorkingArea(Me).Size
            Else
                Me.Location = locSave
                FormBorderStyle = FormBorderStyle.Sizable
                ImageLoadRefresh()
            End If
            Me.TopMost = value
            StatusStrip1.Visible = Not value
            ToolStrip1.Visible = Not value
        End Set
    End Property

End Class

