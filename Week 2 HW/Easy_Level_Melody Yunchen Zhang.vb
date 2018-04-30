Sub Easy_Level()

  ' ' --------------------------------------------
    ' LOOP THROUGH ALL YEARS
    ' --------------------------------------------
    For Each ws In Worksheets

        ' Set an initial variable for holding the ticker
        Dim ticker As String
    
        ' Set an initial variable for holding the total of each ticker
        Dim Ticker_Total As Double
        Ticker_Total = 0
        
        'Build Total Amount Table
        ws.Range("I1") = "Ticker"
        ws.Range("J1") = "Total Stock Volume"
        
        ' Keep track of the location for each ticker in the total amount table
        Dim Total_Amount_Row As Integer
        Total_Amount_Row = 2
    
        ' Determine the Last Row
        LastRow = ws.Cells(Rows.Count, 1).End(xlUp).Row

            ' Loop through all stock data
            For i = 2 To LastRow

                    ' Check if we are still within the same ticker, if it is not...
                    If ws.Cells(i + 1, 1).Value <> ws.Cells(i, 1).Value Then
                
                      ' Set the ticker
                      ticker = ws.Cells(i, 1).Value
                
                      ' Add to the ticker Total
                      Ticker_Total = Ticker_Total + ws.Cells(i, 7).Value
                
                      ' Print the ticker in the total amount Table
                      ws.Range("I" & Total_Amount_Row).Value = ticker
                
                      ' Print the ticker total to the total amount Table
                      ws.Range("J" & Total_Amount_Row).Value = Ticker_Total
                
                      ' Add one to the total amount table row
                      Total_Amount_Row = Total_Amount_Row + 1
                      
                      ' Reset the Ticker Total
                      Ticker_Total = 0
                
                    ' If the cell immediately following a row is the same ticker...
                    Else
                
                      ' Add to the Ticker Total
                      Ticker_Total = Ticker_Total + ws.Cells(i, 7).Value
                
                    End If

             Next i

    Next ws
    
End Sub

