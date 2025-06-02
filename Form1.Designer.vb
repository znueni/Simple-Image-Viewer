<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form1))
        ToolStrip1 = New ToolStrip()
        ToolStripFILE = New ToolStripDropDownButton()
        mnuOpen = New ToolStripMenuItem()
        ToolStripSeparator1 = New ToolStripSeparator()
        mnuSave = New ToolStripMenuItem()
        mnuSaveAs = New ToolStripMenuItem()
        ToolStripMenuItem1 = New ToolStripSeparator()
        mnuDelete = New ToolStripMenuItem()
        ToolStripSeparator6 = New ToolStripSeparator()
        mnuExit = New ToolStripMenuItem()
        ToolStripSeparator5 = New ToolStripSeparator()
        ToolStripEDIT = New ToolStripDropDownButton()
        mnuRotateLEFT = New ToolStripMenuItem()
        mnuRotateRIGHT = New ToolStripMenuItem()
        ToolStripMenuItem2 = New ToolStripSeparator()
        mnuCrop = New ToolStripMenuItem()
        ToolStripSeparator4 = New ToolStripSeparator()
        ToolStripVIEW = New ToolStripDropDownButton()
        mnuView_Autosize = New ToolStripMenuItem()
        mnuView_Orig = New ToolStripMenuItem()
        mnuFullscreen = New ToolStripButton()
        ToolStripSeparator2 = New ToolStripSeparator()
        mnuCopy = New ToolStripButton()
        mnuPaste = New ToolStripButton()
        ToolStripSeparator3 = New ToolStripSeparator()
        mnuNavigatePrev = New ToolStripButton()
        mnuNavigateNext = New ToolStripButton()
        StatusStrip1 = New StatusStrip()
        lblStatus = New ToolStripStatusLabel()
        lblfilename = New ToolStripStatusLabel()
        lblFilesInDir = New ToolStripStatusLabel()
        pic = New PictureBox()
        Panel1 = New Panel()
        ToolStrip1.SuspendLayout()
        StatusStrip1.SuspendLayout()
        CType(pic, ComponentModel.ISupportInitialize).BeginInit()
        Panel1.SuspendLayout()
        SuspendLayout()
        ' 
        ' ToolStrip1
        ' 
        ToolStrip1.ImageScalingSize = New Size(32, 32)
        ToolStrip1.Items.AddRange(New ToolStripItem() {ToolStripFILE, ToolStripSeparator5, ToolStripEDIT, ToolStripSeparator4, ToolStripVIEW, mnuFullscreen, ToolStripSeparator2, mnuCopy, mnuPaste, ToolStripSeparator3, mnuNavigatePrev, mnuNavigateNext})
        ToolStrip1.Location = New Point(0, 0)
        ToolStrip1.Name = "ToolStrip1"
        ToolStrip1.RenderMode = ToolStripRenderMode.System
        ToolStrip1.Size = New Size(1602, 41)
        ToolStrip1.TabIndex = 0
        ' 
        ' ToolStripFILE
        ' 
        ToolStripFILE.DropDownItems.AddRange(New ToolStripItem() {mnuOpen, ToolStripSeparator1, mnuSave, mnuSaveAs, ToolStripMenuItem1, mnuDelete, ToolStripSeparator6, mnuExit})
        ToolStripFILE.Image = CType(resources.GetObject("ToolStripFILE.Image"), Image)
        ToolStripFILE.ImageTransparentColor = Color.Magenta
        ToolStripFILE.Name = "ToolStripFILE"
        ToolStripFILE.Size = New Size(88, 36)
        ToolStripFILE.Text = "File"
        ' 
        ' mnuOpen
        ' 
        mnuOpen.Name = "mnuOpen"
        mnuOpen.ShortcutKeys = Keys.Control Or Keys.O
        mnuOpen.Size = New Size(270, 34)
        mnuOpen.Text = "Open..."
        ' 
        ' ToolStripSeparator1
        ' 
        ToolStripSeparator1.Name = "ToolStripSeparator1"
        ToolStripSeparator1.Size = New Size(267, 6)
        ' 
        ' mnuSave
        ' 
        mnuSave.Name = "mnuSave"
        mnuSave.Size = New Size(270, 34)
        mnuSave.Text = "Save"
        ' 
        ' mnuSaveAs
        ' 
        mnuSaveAs.Name = "mnuSaveAs"
        mnuSaveAs.ShortcutKeys = Keys.Control Or Keys.S
        mnuSaveAs.Size = New Size(270, 34)
        mnuSaveAs.Text = "Save as..."
        ' 
        ' ToolStripMenuItem1
        ' 
        ToolStripMenuItem1.Name = "ToolStripMenuItem1"
        ToolStripMenuItem1.Size = New Size(267, 6)
        ' 
        ' mnuDelete
        ' 
        mnuDelete.Name = "mnuDelete"
        mnuDelete.ShortcutKeys = Keys.Control Or Keys.Delete
        mnuDelete.Size = New Size(270, 34)
        mnuDelete.Text = "Delete"
        ' 
        ' ToolStripSeparator6
        ' 
        ToolStripSeparator6.Name = "ToolStripSeparator6"
        ToolStripSeparator6.Size = New Size(267, 6)
        ' 
        ' mnuExit
        ' 
        mnuExit.Name = "mnuExit"
        mnuExit.Size = New Size(270, 34)
        mnuExit.Text = "Exit"
        ' 
        ' ToolStripSeparator5
        ' 
        ToolStripSeparator5.Name = "ToolStripSeparator5"
        ToolStripSeparator5.Size = New Size(6, 41)
        ' 
        ' ToolStripEDIT
        ' 
        ToolStripEDIT.DropDownItems.AddRange(New ToolStripItem() {mnuRotateLEFT, mnuRotateRIGHT, ToolStripMenuItem2, mnuCrop})
        ToolStripEDIT.Image = CType(resources.GetObject("ToolStripEDIT.Image"), Image)
        ToolStripEDIT.ImageTransparentColor = Color.Magenta
        ToolStripEDIT.Name = "ToolStripEDIT"
        ToolStripEDIT.Size = New Size(92, 36)
        ToolStripEDIT.Text = "Edit"
        ' 
        ' mnuRotateLEFT
        ' 
        mnuRotateLEFT.Image = CType(resources.GetObject("mnuRotateLEFT.Image"), Image)
        mnuRotateLEFT.Name = "mnuRotateLEFT"
        mnuRotateLEFT.ShortcutKeys = Keys.Control Or Keys.L
        mnuRotateLEFT.Size = New Size(269, 34)
        mnuRotateLEFT.Text = "Rotate left"
        ' 
        ' mnuRotateRIGHT
        ' 
        mnuRotateRIGHT.Image = CType(resources.GetObject("mnuRotateRIGHT.Image"), Image)
        mnuRotateRIGHT.Name = "mnuRotateRIGHT"
        mnuRotateRIGHT.ShortcutKeys = Keys.Control Or Keys.R
        mnuRotateRIGHT.Size = New Size(269, 34)
        mnuRotateRIGHT.Text = "Rotate right"
        ' 
        ' ToolStripMenuItem2
        ' 
        ToolStripMenuItem2.Name = "ToolStripMenuItem2"
        ToolStripMenuItem2.Size = New Size(266, 6)
        ' 
        ' mnuCrop
        ' 
        mnuCrop.Image = CType(resources.GetObject("mnuCrop.Image"), Image)
        mnuCrop.Name = "mnuCrop"
        mnuCrop.ShortcutKeys = Keys.Control Or Keys.Y
        mnuCrop.Size = New Size(269, 34)
        mnuCrop.Text = "Crop"
        ' 
        ' ToolStripSeparator4
        ' 
        ToolStripSeparator4.Name = "ToolStripSeparator4"
        ToolStripSeparator4.Size = New Size(6, 41)
        ' 
        ' ToolStripVIEW
        ' 
        ToolStripVIEW.DropDownItems.AddRange(New ToolStripItem() {mnuView_Autosize, mnuView_Orig})
        ToolStripVIEW.Image = CType(resources.GetObject("ToolStripVIEW.Image"), Image)
        ToolStripVIEW.ImageTransparentColor = Color.Magenta
        ToolStripVIEW.Name = "ToolStripVIEW"
        ToolStripVIEW.Size = New Size(99, 36)
        ToolStripVIEW.Text = "View"
        ' 
        ' mnuView_Autosize
        ' 
        mnuView_Autosize.Checked = True
        mnuView_Autosize.CheckState = CheckState.Checked
        mnuView_Autosize.Name = "mnuView_Autosize"
        mnuView_Autosize.Size = New Size(210, 34)
        mnuView_Autosize.Text = "Autosize"
        ' 
        ' mnuView_Orig
        ' 
        mnuView_Orig.Name = "mnuView_Orig"
        mnuView_Orig.Size = New Size(210, 34)
        mnuView_Orig.Text = "Original size"
        ' 
        ' mnuFullscreen
        ' 
        mnuFullscreen.DisplayStyle = ToolStripItemDisplayStyle.Image
        mnuFullscreen.Image = CType(resources.GetObject("mnuFullscreen.Image"), Image)
        mnuFullscreen.ImageTransparentColor = Color.Magenta
        mnuFullscreen.Name = "mnuFullscreen"
        mnuFullscreen.Size = New Size(36, 36)
        mnuFullscreen.Text = "Fullscreen"
        ' 
        ' ToolStripSeparator2
        ' 
        ToolStripSeparator2.Name = "ToolStripSeparator2"
        ToolStripSeparator2.Size = New Size(6, 41)
        ' 
        ' mnuCopy
        ' 
        mnuCopy.DisplayStyle = ToolStripItemDisplayStyle.Image
        mnuCopy.Image = CType(resources.GetObject("mnuCopy.Image"), Image)
        mnuCopy.ImageTransparentColor = Color.Magenta
        mnuCopy.Name = "mnuCopy"
        mnuCopy.Size = New Size(36, 36)
        mnuCopy.Text = "Copy"
        ' 
        ' mnuPaste
        ' 
        mnuPaste.DisplayStyle = ToolStripItemDisplayStyle.Image
        mnuPaste.Image = CType(resources.GetObject("mnuPaste.Image"), Image)
        mnuPaste.ImageTransparentColor = Color.Magenta
        mnuPaste.Name = "mnuPaste"
        mnuPaste.Size = New Size(36, 36)
        mnuPaste.Text = "Paste"
        ' 
        ' ToolStripSeparator3
        ' 
        ToolStripSeparator3.Name = "ToolStripSeparator3"
        ToolStripSeparator3.Size = New Size(6, 41)
        ' 
        ' mnuNavigatePrev
        ' 
        mnuNavigatePrev.DisplayStyle = ToolStripItemDisplayStyle.Image
        mnuNavigatePrev.Enabled = False
        mnuNavigatePrev.Image = CType(resources.GetObject("mnuNavigatePrev.Image"), Image)
        mnuNavigatePrev.ImageTransparentColor = Color.Magenta
        mnuNavigatePrev.Name = "mnuNavigatePrev"
        mnuNavigatePrev.Size = New Size(36, 36)
        mnuNavigatePrev.Text = "Show previous picture in folder"
        ' 
        ' mnuNavigateNext
        ' 
        mnuNavigateNext.DisplayStyle = ToolStripItemDisplayStyle.Image
        mnuNavigateNext.Enabled = False
        mnuNavigateNext.Image = CType(resources.GetObject("mnuNavigateNext.Image"), Image)
        mnuNavigateNext.ImageTransparentColor = Color.Magenta
        mnuNavigateNext.Name = "mnuNavigateNext"
        mnuNavigateNext.Size = New Size(36, 36)
        mnuNavigateNext.Text = "Show next picture in folder"
        ' 
        ' StatusStrip1
        ' 
        StatusStrip1.ImageScalingSize = New Size(20, 20)
        StatusStrip1.Items.AddRange(New ToolStripItem() {lblStatus, lblfilename, lblFilesInDir})
        StatusStrip1.Location = New Point(0, 1029)
        StatusStrip1.Name = "StatusStrip1"
        StatusStrip1.Padding = New Padding(1, 0, 18, 0)
        StatusStrip1.Size = New Size(1602, 32)
        StatusStrip1.TabIndex = 1
        StatusStrip1.Text = "StatusStrip1"
        ' 
        ' lblStatus
        ' 
        lblStatus.Name = "lblStatus"
        lblStatus.Size = New Size(1394, 25)
        lblStatus.Spring = True
        lblStatus.Text = "Ready"
        lblStatus.TextAlign = ContentAlignment.MiddleLeft
        ' 
        ' lblfilename
        ' 
        lblfilename.Name = "lblfilename"
        lblfilename.Size = New Size(71, 25)
        lblfilename.Tag = "(no file)"
        lblfilename.Text = "(no file)"
        ' 
        ' lblFilesInDir
        ' 
        lblFilesInDir.Name = "lblFilesInDir"
        lblFilesInDir.Size = New Size(118, 25)
        lblFilesInDir.Tag = "(no directory)"
        lblFilesInDir.Text = "(no directory)"
        ' 
        ' pic
        ' 
        pic.Dock = DockStyle.Fill
        pic.Location = New Point(0, 0)
        pic.Margin = New Padding(4, 4, 4, 4)
        pic.Name = "pic"
        pic.Size = New Size(1602, 988)
        pic.TabIndex = 2
        pic.TabStop = False
        ' 
        ' Panel1
        ' 
        Panel1.AutoScroll = True
        Panel1.BackColor = Color.Black
        Panel1.Controls.Add(pic)
        Panel1.Dock = DockStyle.Fill
        Panel1.Location = New Point(0, 41)
        Panel1.Margin = New Padding(4, 4, 4, 4)
        Panel1.Name = "Panel1"
        Panel1.Size = New Size(1602, 988)
        Panel1.TabIndex = 3
        ' 
        ' Form1
        ' 
        AutoScaleDimensions = New SizeF(10F, 25F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(1602, 1061)
        Controls.Add(Panel1)
        Controls.Add(StatusStrip1)
        Controls.Add(ToolStrip1)
        Icon = CType(resources.GetObject("$this.Icon"), Icon)
        KeyPreview = True
        Margin = New Padding(4, 4, 4, 4)
        Name = "Form1"
        Text = "Simple Image Viewer"
        ToolStrip1.ResumeLayout(False)
        ToolStrip1.PerformLayout()
        StatusStrip1.ResumeLayout(False)
        StatusStrip1.PerformLayout()
        CType(pic, ComponentModel.ISupportInitialize).EndInit()
        Panel1.ResumeLayout(False)
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents ToolStrip1 As ToolStrip
    Friend WithEvents ToolStripFILE As ToolStripDropDownButton
    Friend WithEvents StatusStrip1 As StatusStrip
    Friend WithEvents pic As PictureBox
    Friend WithEvents mnuOpen As ToolStripMenuItem
    Friend WithEvents ToolStripSeparator1 As ToolStripSeparator
    Friend WithEvents mnuSave As ToolStripMenuItem
    Friend WithEvents mnuSaveAs As ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem1 As ToolStripSeparator
    Friend WithEvents mnuExit As ToolStripMenuItem
    Friend WithEvents mnuFullscreen As ToolStripButton
    Friend WithEvents mnuDelete As ToolStripMenuItem
    Friend WithEvents ToolStripEDIT As ToolStripDropDownButton
    Friend WithEvents mnuRotateLEFT As ToolStripMenuItem
    Friend WithEvents mnuRotateRIGHT As ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem2 As ToolStripSeparator
    Friend WithEvents ToolStripSeparator2 As ToolStripSeparator
    Friend WithEvents mnuCopy As ToolStripButton
    Friend WithEvents mnuPaste As ToolStripButton
    Friend WithEvents ToolStripSeparator3 As ToolStripSeparator
    Friend WithEvents mnuNavigatePrev As ToolStripButton
    Friend WithEvents mnuNavigateNext As ToolStripButton
    Friend WithEvents Panel1 As Panel
    Friend WithEvents mnuCrop As ToolStripMenuItem
    Friend WithEvents ToolStripVIEW As ToolStripDropDownButton
    Friend WithEvents ToolStripSeparator5 As ToolStripSeparator
    Friend WithEvents ToolStripSeparator4 As ToolStripSeparator
    Friend WithEvents mnuView_Autosize As ToolStripMenuItem
    Friend WithEvents mnuView_Orig As ToolStripMenuItem
    Friend WithEvents ToolStripSeparator6 As ToolStripSeparator
    Friend WithEvents lblStatus As ToolStripStatusLabel
    Friend WithEvents lblFilesInDir As ToolStripStatusLabel
    Friend WithEvents lblfilename As ToolStripStatusLabel

End Class
