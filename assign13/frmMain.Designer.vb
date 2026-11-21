<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMain
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
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
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btnAddPassenger = New System.Windows.Forms.Button()
        Me.btnShowPassenger = New System.Windows.Forms.Button()
        Me.btnUpdatePassenger = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(319, 108)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(155, 16)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Passenger Management"
        '
        'btnAddPassenger
        '
        Me.btnAddPassenger.Location = New System.Drawing.Point(332, 127)
        Me.btnAddPassenger.Name = "btnAddPassenger"
        Me.btnAddPassenger.Size = New System.Drawing.Size(142, 23)
        Me.btnAddPassenger.TabIndex = 1
        Me.btnAddPassenger.Text = "Add Passenger"
        Me.btnAddPassenger.UseVisualStyleBackColor = True
        '
        'btnShowPassenger
        '
        Me.btnShowPassenger.Location = New System.Drawing.Point(332, 156)
        Me.btnShowPassenger.Name = "btnShowPassenger"
        Me.btnShowPassenger.Size = New System.Drawing.Size(142, 23)
        Me.btnShowPassenger.TabIndex = 2
        Me.btnShowPassenger.Text = "Show Passenger"
        Me.btnShowPassenger.UseVisualStyleBackColor = True
        '
        'btnUpdatePassenger
        '
        Me.btnUpdatePassenger.Location = New System.Drawing.Point(332, 185)
        Me.btnUpdatePassenger.Name = "btnUpdatePassenger"
        Me.btnUpdatePassenger.Size = New System.Drawing.Size(142, 23)
        Me.btnUpdatePassenger.TabIndex = 3
        Me.btnUpdatePassenger.Text = "Update Passenger"
        Me.btnUpdatePassenger.UseVisualStyleBackColor = True
        '
        'frmMain
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(800, 450)
        Me.Controls.Add(Me.btnUpdatePassenger)
        Me.Controls.Add(Me.btnShowPassenger)
        Me.Controls.Add(Me.btnAddPassenger)
        Me.Controls.Add(Me.Label1)
        Me.Name = "frmMain"
        Me.Text = "Passenger Management"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents btnAddPassenger As Button
    Friend WithEvents btnShowPassenger As Button
    Friend WithEvents btnUpdatePassenger As Button
End Class
