Imports Python.Runtime

#Disable Warning IDE1006
Public Class frmMain
    Private ReadOnly Property IsPythonInitialized As Boolean
        Get
            Return PythonEngine.IsInitialized
        End Get
    End Property

    Private Sub frmMain_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        SetupPython()
        LoadSampleCode()
        ' Set default theme to Light
        cboTheme.SelectedIndex = 0
    End Sub

    Private Sub SetupPython()
        Try
            Runtime.PythonDLL = "python314"
            If Not IsPythonInitialized Then PythonEngine.Initialize()
        Catch ex As Exception
            MessageBox.Show($"Python initialization failed: {ex.Message}", "Error",
                MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub LoadSampleCode()
        txtPythonCode.Text = "# Welcome to Python Studio Mini!
# Write your Python code here and click ""Run Python Code""

print(""Hello from Python Studio Mini!"")

# Try some calculations
x = 10
y = 20
print(f""Sum of {x} and {y} is: {x + y}"")

# List comprehension example
numbers = [1, 2, 3, 4, 5]
squared = [n**2 for n in numbers]
print(""Squared numbers:"", squared)

# Function example
def greet(name: str) -> str:
    return f""Hello, {name}!""

print(greet(""Python Developer""))"
    End Sub

    Private Sub btnRunCode_Click(sender As Object, e As EventArgs) Handles btnRunCode.Click
        If String.IsNullOrWhiteSpace(txtPythonCode.Text) Then
            MessageBox.Show("Please enter some Python code first.", "Information",
                MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return
        End If

        txtOutput.Clear()

        Try
            If Not IsPythonInitialized Then
                SetupPython()
                If Not IsPythonInitialized Then
                    MessageBox.Show("Python is not initialized properly.", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Exit Sub
                End If
            End If

            Using Py.GIL()
                ' Redirect sys.stdout
                Dim sysModule = Py.Import("sys")
                Dim oldStdout = sysModule.GetAttr("stdout")
                Dim scope = Py.CreateScope()
                ' Create a custom stdout redirector
                scope.Exec("import sys
from io import StringIO

class StdoutRedirector:
    def __init__(self):
        self.buffer = StringIO()
    def write(self, data):
        self.buffer.write(data)
    def flush(self):
        pass
    def getvalue(self):
        return self.buffer.getvalue()

redirector = StdoutRedirector()
sys.stdout = redirector")

                Try
                    ' Execute user code and get captured output
                    scope.Exec(txtPythonCode.Text)
                    Dim output = scope.Eval("redirector.getvalue()").As(Of String)()
                    ' Replace Python's LF newlines with Windows CRLF newlines
                    txtOutput.Text = output.Replace(vbLf, vbCrLf)
                Catch pyEx As PythonException
                    MessageBox.Show($"Error executing Python code: {pyEx.Message}", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error)
                Finally
                    ' Restore stdout
                    sysModule.SetAttr("stdout", oldStdout)
                End Try
            End Using
        Catch ex As Exception
            MessageBox.Show($"Unknown error: {ex.Message}", "Error",
                MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnClear_Click(sender As Object, e As EventArgs) Handles btnClear.Click
        txtPythonCode.Clear()
        txtOutput.Clear()
        LoadSampleCode()
    End Sub

    Private Sub cboTheme_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboTheme.SelectedIndexChanged
        Dim darkColor As Color = Color.FromArgb(30, 30, 30)
        If cboTheme.SelectedIndex = 0 Then
            ' Light theme
            lblCodeTitle.ForeColor = Color.Black
            lblOutputTitle.ForeColor = Color.Black
            txtPythonCode.BackColor = Color.White
            txtPythonCode.ForeColor = Color.DarkBlue
            txtOutput.BackColor = Color.White
            txtOutput.ForeColor = Color.Black
            BackColor = Color.White
        Else
            ' Dark theme
            lblCodeTitle.ForeColor = Color.LightGray
            lblOutputTitle.ForeColor = Color.LightGray
            txtPythonCode.BackColor = darkColor
            txtPythonCode.ForeColor = Color.LightBlue
            txtOutput.BackColor = darkColor
            txtOutput.ForeColor = Color.LightGray
            BackColor = darkColor
        End If
    End Sub

    Protected Overrides Sub OnFormClosing(e As FormClosingEventArgs)
        MyBase.OnFormClosing(e)
        If IsPythonInitialized Then PythonEngine.Shutdown()
    End Sub

    <STAThread> Friend Shared Sub Main()
        Application.SetHighDpiMode(HighDpiMode.SystemAware)
        Application.EnableVisualStyles()
        Application.SetCompatibleTextRenderingDefault(False)
        Application.Run(New frmMain)
    End Sub
End Class