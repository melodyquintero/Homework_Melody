Sub Moderate_Level()

  ' ' --------------------------------------------
    ' LOOP THROUGH ALL YEARS
    ' --------------------------------------------
    For Each ws In Worksheets

        ' Set an initial variable for holding the ticker
        Dim ticker As String
    
        ' Set an initial variable for holding the total of each ticker
        Dim Ticker_Total As Double
        Ticker_Total = 0

        ' Set initial variables for holding the yearly change
        Dim open_year As Double
        Dim close_year As Double
        Dim yearly_change As Double
        
        ' Set an initial variable for holding the Percent change
        Dim Pecent_change As Double

        'Build Total Amount Table
        ws.Range("I1") = "Ticker"
        ws.Range("J1") = "Yearly Change"
        ws.Range("K1") = "Percent Change"
        ws.Range("L1") = "Total Stock Volume"

        
        ' Keep track of the location for each ticker in the total amount table
        Dim Total_Amount_Row As Integer
        Total_Amount_Row = 2
    
        ' Determine the Last Row
        LastRow = ws.Cells(Rows.Count, 1).End(xlUp).Row

            ' Loop through all stock data
        For i = 2 To LastRow

                    'check if this is the first row of same ticker
                    If ws.Cells(i, 1).Value <> ws.Cells(i - 1, 1).Value Then
                        'set the open year
                        open_year = ws.Cells(i, 3).Value
                    End If

                        ' Check if we are still within the same ticker, if it is not...
                        If ws.Cells(i + 1, 1).Value <> ws.Cells(i, 1).Value Then
                    
                              ' Set the ticker
                              ticker = ws.Cells(i, 1).Value
                        
                              ' Add to the ticker Total
                              Ticker_Total = Ticker_Total + ws.Cells(i, 7).Value
        
                              'Caculate the yearly change
                              close_year = ws.Cells(i, 6).Value
                              yearly_change = close_year - open_year
        
                                'Caculate the percentage change
                                If open_year > 0 Then
                                  percent_change = (close_year - open_year) / open_year
                                End If
    
                              ' Print the variables in the total amount Table
                              ws.Range("I" & Total_Amount_Row).Value = ticker
                              ws.Range("J" & Total_Amount_Row).Value = yearly_change
                              ws.Range("K" & Total_Amount_Row).Value = percent_change
                              ws.Range("L" & Total_Amount_Row).Value = Ticker_Total

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
                                'Format the percent change in total amount table
                              ws.Range("K2:K" &Total_Amount_Row).numberformat = "0.00%"
                                'Format the yearly change in total amount table
                              For j = 2 to Total_Amount_Row
                                  If ws.cells(j,10).value >=0 then
                                      ws.cells(j,10).Interior.ColorIndex = 4
                                  Else
                                      ws.cells(j,10).Interior.ColorIndex = 3
                                  End If
                              next j 


    Next ws
    
End Sub

