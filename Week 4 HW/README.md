
# Heroes Of Pymoli Data Analysis
* Of the 573 active players, the vast majority are male (81.15%). There also exists, a smaller, but notable proportion of female players (17.45%). Male players tend to spend more on higher price items.

* Our peak age demographic falls between 20-24 (45.2%) with secondary groups falling between 15-19 (17.45%) and 25-29 (15.18%). However, players aged 40+ (1.92%) are willing to spend more on higher price items, followed by 25-29 group.

* Player with SN:Undirrala66 purchased the most items(5) and spent $17.06 in total. The most popular item is Item ID :39, Betrayal, Whisper of Grieving Widows, while Retribution Axe (Item ID:34) generates the highest profits among all items.
-----


```python
# Dependencies
import pandas as pd

# Importing JSON Files
Data = pd.read_json('C:/Users/cheun/Desktop/purchase_data.json')
Data.head()
```




<div>
<style scoped>
    .dataframe tbody tr th:only-of-type {
        vertical-align: middle;
    }

    .dataframe tbody tr th {
        vertical-align: top;
    }

    .dataframe thead th {
        text-align: right;
    }
</style>
<table border="1" class="dataframe">
  <thead>
    <tr style="text-align: right;">
      <th></th>
      <th>Age</th>
      <th>Gender</th>
      <th>Item ID</th>
      <th>Item Name</th>
      <th>Price</th>
      <th>SN</th>
    </tr>
  </thead>
  <tbody>
    <tr>
      <th>0</th>
      <td>38</td>
      <td>Male</td>
      <td>165</td>
      <td>Bone Crushing Silver Skewer</td>
      <td>3.37</td>
      <td>Aelalis34</td>
    </tr>
    <tr>
      <th>1</th>
      <td>21</td>
      <td>Male</td>
      <td>119</td>
      <td>Stormbringer, Dark Blade of Ending Misery</td>
      <td>2.32</td>
      <td>Eolo46</td>
    </tr>
    <tr>
      <th>2</th>
      <td>34</td>
      <td>Male</td>
      <td>174</td>
      <td>Primitive Blade</td>
      <td>2.46</td>
      <td>Assastnya25</td>
    </tr>
    <tr>
      <th>3</th>
      <td>21</td>
      <td>Male</td>
      <td>92</td>
      <td>Final Critic</td>
      <td>1.36</td>
      <td>Pheusrical25</td>
    </tr>
    <tr>
      <th>4</th>
      <td>23</td>
      <td>Male</td>
      <td>63</td>
      <td>Stormfury Mace</td>
      <td>1.27</td>
      <td>Aela59</td>
    </tr>
  </tbody>
</table>
</div>



## Player Count


```python
# Counts unique values in column "SN" to identify players number
Player_Count = len(Data["SN"].value_counts())

# Create a Dataframe of total players counts
df_PlayerCount = pd.DataFrame([{"Total Players": Player_Count}])
df_PlayerCount
```




<div>
<style scoped>
    .dataframe tbody tr th:only-of-type {
        vertical-align: middle;
    }

    .dataframe tbody tr th {
        vertical-align: top;
    }

    .dataframe thead th {
        text-align: right;
    }
</style>
<table border="1" class="dataframe">
  <thead>
    <tr style="text-align: right;">
      <th></th>
      <th>Total Players</th>
    </tr>
  </thead>
  <tbody>
    <tr>
      <th>0</th>
      <td>573</td>
    </tr>
  </tbody>
</table>
</div>



## Purchasing Analysis (Total)


```python
# Counts unique values in column "Item ID" to num of unique items
Number_items = len(Data["Item ID"].value_counts())

# Counts average price
Avg_price = Data["Price"].mean()

# Counts number of purchases
Purchases_number = Data["Item ID"].count()

#Sum up price to calculate total revenue
Total_revenue = Data["Price"].sum()

#Create DataFrame of purchasing analysis
df_PurchasingTotal = pd.DataFrame([{"Number of Unique Items": Number_items,
                                        "Average Price":Avg_price,
                                        "Number of Purchases":Purchases_number,
                                        "Total Revenue":Total_revenue}])

# Organise Dataframe columns
df_PurchasingTotal = df_PurchasingTotal[["Number of Unique Items","Average Price","Number of Purchases","Total Revenue"]]

# Format Price and Revenue columns
df_PurchasingTotal["Average Price"] = df_PurchasingTotal["Average Price"].map('${:,.2f}'.format)
df_PurchasingTotal["Total Revenue"] = df_PurchasingTotal["Total Revenue"].map('${:,.2f}'.format)

df_PurchasingTotal
```




<div>
<style scoped>
    .dataframe tbody tr th:only-of-type {
        vertical-align: middle;
    }

    .dataframe tbody tr th {
        vertical-align: top;
    }

    .dataframe thead th {
        text-align: right;
    }
</style>
<table border="1" class="dataframe">
  <thead>
    <tr style="text-align: right;">
      <th></th>
      <th>Number of Unique Items</th>
      <th>Average Price</th>
      <th>Number of Purchases</th>
      <th>Total Revenue</th>
    </tr>
  </thead>
  <tbody>
    <tr>
      <th>0</th>
      <td>183</td>
      <td>$2.93</td>
      <td>780</td>
      <td>$2,286.33</td>
    </tr>
  </tbody>
</table>
</div>



## Gender Demographics


```python
# Groupby the "Gender" and count unique value of players by Gender, named as total count
Gender_Count = Data.groupby("Gender")["SN"].nunique().reset_index(name='Total Count')

# Calculate percentage of players by genders and format the output to 2 decimals
Gender_Count["Percentage of Players"] = (Gender_Count["Total Count"]/Player_Count) * 100
Gender_Count["Percentage of Players"] = Gender_Count["Percentage of Players"].map('{:,.2f}'.format)

# Sort by total count
Gender_Count = Gender_Count.sort_values("Total Count", ascending=False)

# Reorganise the columns and set "Gender" as index
Gender_Count = Gender_Count[["Gender","Percentage of Players","Total Count"]].set_index("Gender")

# Remove the index header
Gender_Count.index.name = None

Gender_Count
```




<div>
<style scoped>
    .dataframe tbody tr th:only-of-type {
        vertical-align: middle;
    }

    .dataframe tbody tr th {
        vertical-align: top;
    }

    .dataframe thead th {
        text-align: right;
    }
</style>
<table border="1" class="dataframe">
  <thead>
    <tr style="text-align: right;">
      <th></th>
      <th>Percentage of Players</th>
      <th>Total Count</th>
    </tr>
  </thead>
  <tbody>
    <tr>
      <th>Male</th>
      <td>81.15</td>
      <td>465</td>
    </tr>
    <tr>
      <th>Female</th>
      <td>17.45</td>
      <td>100</td>
    </tr>
    <tr>
      <th>Other / Non-Disclosed</th>
      <td>1.40</td>
      <td>8</td>
    </tr>
  </tbody>
</table>
</div>




## Purchasing Analysis (Gender)


```python
#Count purchase number by gender
Purchase_Count_Gender = Data.groupby("Gender")["SN"].count()

#Calculate the average purchase price by gender
Avg_PurchasePrice_Gender = Data.groupby("Gender")["Price"].mean()

#Calculate total purchase value by gender
Purchase_Value_Gender = Purchase_Count_Gender * Avg_PurchasePrice_Gender

#Calculate normalized totals by gender
Normalized_Totals_Gender = Purchase_Value_Gender/Gender_Count["Total Count"]

#Align the above series into one dataframe with same index "Gender"
df_PurchasingGender = pd.concat([Purchase_Count_Gender, Avg_PurchasePrice_Gender, Purchase_Value_Gender, Normalized_Totals_Gender], axis=1)

#Rename dataframe
df_PurchasingGender = df_PurchasingGender.rename(columns={"SN":"Purchase Count", 
                                                          "Price":"Average Purchase Price", 
                                                           0:"Total Purchase Value",
                                                           1:"Normalized Totals"})
#Format dataframe
df_PurchasingGender['Average Purchase Price'] = df_PurchasingGender['Average Purchase Price'].map('${:,.2f}'.format)
df_PurchasingGender['Total Purchase Value'] = df_PurchasingGender['Total Purchase Value'].map('${:,.2f}'.format)
df_PurchasingGender['Normalized Totals'] = df_PurchasingGender['Normalized Totals'].map('${:,.2f}'.format)

df_PurchasingGender
```




<div>
<style scoped>
    .dataframe tbody tr th:only-of-type {
        vertical-align: middle;
    }

    .dataframe tbody tr th {
        vertical-align: top;
    }

    .dataframe thead th {
        text-align: right;
    }
</style>
<table border="1" class="dataframe">
  <thead>
    <tr style="text-align: right;">
      <th></th>
      <th>Purchase Count</th>
      <th>Average Purchase Price</th>
      <th>Total Purchase Value</th>
      <th>Normalized Totals</th>
    </tr>
    <tr>
      <th>Gender</th>
      <th></th>
      <th></th>
      <th></th>
      <th></th>
    </tr>
  </thead>
  <tbody>
    <tr>
      <th>Female</th>
      <td>136</td>
      <td>$2.82</td>
      <td>$382.91</td>
      <td>$3.83</td>
    </tr>
    <tr>
      <th>Male</th>
      <td>633</td>
      <td>$2.95</td>
      <td>$1,867.68</td>
      <td>$4.02</td>
    </tr>
    <tr>
      <th>Other / Non-Disclosed</th>
      <td>11</td>
      <td>$3.25</td>
      <td>$35.74</td>
      <td>$4.47</td>
    </tr>
  </tbody>
</table>
</div>



## Age Demographics


```python
# Add new columns named "Age Group", Cut Age data and place the age into age group bins
Data["Age Group"] = pd.cut(Data["Age"], [0, 9, 14, 19, 24, 29, 34, 39, 150],\
                   labels=['<10', '10-14', '15-19', '20-24','25-29','30-34','35-39','40+'])

# Groupby the "Age Group" and count unique value of players in each group, named as total count
Age_count = Data.groupby("Age Group")["SN"].nunique().reset_index(name='Total Count')

# Calculate Percentage of players in each age group
Age_count["Percentage of Players"] = (Age_count["Total Count"]/Player_Count) * 100

# Format percentage into 2 decimals
Age_count["Percentage of Players"] = Age_count["Percentage of Players"].map('{:,.2f}'.format)

# Reorganise the columns and set "Age Group" column as the index
Age_count = Age_count[["Age Group","Percentage of Players","Total Count"]].set_index("Age Group")

# Remove index header
Age_count.index.name = None

Age_count
```




<div>
<style scoped>
    .dataframe tbody tr th:only-of-type {
        vertical-align: middle;
    }

    .dataframe tbody tr th {
        vertical-align: top;
    }

    .dataframe thead th {
        text-align: right;
    }
</style>
<table border="1" class="dataframe">
  <thead>
    <tr style="text-align: right;">
      <th></th>
      <th>Percentage of Players</th>
      <th>Total Count</th>
    </tr>
  </thead>
  <tbody>
    <tr>
      <th>&lt;10</th>
      <td>3.32</td>
      <td>19</td>
    </tr>
    <tr>
      <th>10-14</th>
      <td>4.01</td>
      <td>23</td>
    </tr>
    <tr>
      <th>15-19</th>
      <td>17.45</td>
      <td>100</td>
    </tr>
    <tr>
      <th>20-24</th>
      <td>45.20</td>
      <td>259</td>
    </tr>
    <tr>
      <th>25-29</th>
      <td>15.18</td>
      <td>87</td>
    </tr>
    <tr>
      <th>30-34</th>
      <td>8.20</td>
      <td>47</td>
    </tr>
    <tr>
      <th>35-39</th>
      <td>4.71</td>
      <td>27</td>
    </tr>
    <tr>
      <th>40+</th>
      <td>1.92</td>
      <td>11</td>
    </tr>
  </tbody>
</table>
</div>



## Purchasing Analysis (Age)


```python
#Count purchase number by Age
Purchase_Count_Age = Data.groupby("Age Group")["SN"].count()

#Calculate the average purchase price by Age
Avg_PurchasePrice_Age = Data.groupby("Age Group")["Price"].mean()

#Calculate total purchase value by gender
Purchase_Value_Age = Purchase_Count_Age * Avg_PurchasePrice_Age

#Calculate normalized totals by gender
Normalized_Totals_Age = Purchase_Value_Age/Age_count["Total Count"]

#Align the above series into one dataframe with same index "Gender"
df_PurchasingAge = pd.concat([Purchase_Count_Age, Avg_PurchasePrice_Age, Purchase_Value_Age, Normalized_Totals_Age], axis=1)

#Rename dataframe
df_PurchasingAge = df_PurchasingAge.rename(columns={"SN":"Purchase Count", 
                                                    "Price":"Average Purchase Price", 
                                                     0:"Total Purchase Value",
                                                     1:"Normalized Totals"})
#Format dataframe
df_PurchasingAge ['Average Purchase Price'] = df_PurchasingAge ['Average Purchase Price'].map('${:,.2f}'.format)
df_PurchasingAge ['Total Purchase Value'] = df_PurchasingAge ['Total Purchase Value'].map('${:,.2f}'.format)
df_PurchasingAge ['Normalized Totals'] = df_PurchasingAge ['Normalized Totals'].map('${:,.2f}'.format)

# Remove index header
df_PurchasingAge.index.name = None

# Move the first row to the bottom
new_rows = [i for i in range(len(df_PurchasingAge)) if i != 0]+[0]
df_PurchasingAge.iloc[new_rows]
```




<div>
<style scoped>
    .dataframe tbody tr th:only-of-type {
        vertical-align: middle;
    }

    .dataframe tbody tr th {
        vertical-align: top;
    }

    .dataframe thead th {
        text-align: right;
    }
</style>
<table border="1" class="dataframe">
  <thead>
    <tr style="text-align: right;">
      <th></th>
      <th>Purchase Count</th>
      <th>Average Purchase Price</th>
      <th>Total Purchase Value</th>
      <th>Normalized Totals</th>
    </tr>
  </thead>
  <tbody>
    <tr>
      <th>10-14</th>
      <td>35</td>
      <td>$2.77</td>
      <td>$96.95</td>
      <td>$4.22</td>
    </tr>
    <tr>
      <th>15-19</th>
      <td>133</td>
      <td>$2.91</td>
      <td>$386.42</td>
      <td>$3.86</td>
    </tr>
    <tr>
      <th>20-24</th>
      <td>336</td>
      <td>$2.91</td>
      <td>$978.77</td>
      <td>$3.78</td>
    </tr>
    <tr>
      <th>25-29</th>
      <td>125</td>
      <td>$2.96</td>
      <td>$370.33</td>
      <td>$4.26</td>
    </tr>
    <tr>
      <th>30-34</th>
      <td>64</td>
      <td>$3.08</td>
      <td>$197.25</td>
      <td>$4.20</td>
    </tr>
    <tr>
      <th>35-39</th>
      <td>42</td>
      <td>$2.84</td>
      <td>$119.40</td>
      <td>$4.42</td>
    </tr>
    <tr>
      <th>40+</th>
      <td>17</td>
      <td>$3.16</td>
      <td>$53.75</td>
      <td>$4.89</td>
    </tr>
    <tr>
      <th>&lt;10</th>
      <td>28</td>
      <td>$2.98</td>
      <td>$83.46</td>
      <td>$4.39</td>
    </tr>
  </tbody>
</table>
</div>



## Top Spenders


```python
# Count purchase number by SN
Purchase_Count_SN = Data.groupby("SN")["Item ID"].count()

# Calculate the average purchase price by SN
Avg_PurchasePrice_SN = Data.groupby("SN")["Price"].mean()

# Calculate total purchase value by SN
Purchase_Value_SN = Purchase_Count_SN * Avg_PurchasePrice_SN

# Align the above series into one dataframe with same index "SN"
df_Spenders = pd.concat([Purchase_Count_SN, Avg_PurchasePrice_SN, Purchase_Value_SN], axis=1)

# Rename dataframe and sort total purchasing value from highest to lowest
df_Spenders = df_Spenders.rename(columns={"Item ID":"Purchase Count", 
                                          "Price":"Average Purchase Price", 
                                            0:"Total Purchase Value"}).sort_values("Total Purchase Value", ascending=False)

#Format dataframe
df_Spenders ['Average Purchase Price'] = df_Spenders ['Average Purchase Price'].map('${:,.2f}'.format)
df_Spenders ['Total Purchase Value'] = df_Spenders ['Total Purchase Value'].map('${:,.2f}'.format)

# Keep the top 5 spenders
df_TopSpenders = df_Spenders[:5]

df_TopSpenders
```




<div>
<style scoped>
    .dataframe tbody tr th:only-of-type {
        vertical-align: middle;
    }

    .dataframe tbody tr th {
        vertical-align: top;
    }

    .dataframe thead th {
        text-align: right;
    }
</style>
<table border="1" class="dataframe">
  <thead>
    <tr style="text-align: right;">
      <th></th>
      <th>Purchase Count</th>
      <th>Average Purchase Price</th>
      <th>Total Purchase Value</th>
    </tr>
    <tr>
      <th>SN</th>
      <th></th>
      <th></th>
      <th></th>
    </tr>
  </thead>
  <tbody>
    <tr>
      <th>Undirrala66</th>
      <td>5</td>
      <td>$3.41</td>
      <td>$17.06</td>
    </tr>
    <tr>
      <th>Saedue76</th>
      <td>4</td>
      <td>$3.39</td>
      <td>$13.56</td>
    </tr>
    <tr>
      <th>Mindimnya67</th>
      <td>4</td>
      <td>$3.18</td>
      <td>$12.74</td>
    </tr>
    <tr>
      <th>Haellysu29</th>
      <td>3</td>
      <td>$4.24</td>
      <td>$12.73</td>
    </tr>
    <tr>
      <th>Eoda93</th>
      <td>3</td>
      <td>$3.86</td>
      <td>$11.58</td>
    </tr>
  </tbody>
</table>
</div>



## Most Popular Items


```python
# Count purchase number by Item ID
Purchase_Count_ItemID = Data.groupby(["Item ID", "Item Name"])["SN"].count().sort_values(0, ascending=False)

# Identify item price by Item ID
Item_Price = Data.groupby(["Item ID", "Item Name"])["Price"].mean()

# Calculate total purchase value by Item ID
Purchase_Value_ItemID = Purchase_Count_ItemID * Item_Price

# Align the above series into one dataframe with same indexes "ItemID" & "Item Name"
df_Items = pd.concat([Purchase_Count_ItemID, Item_Price, Purchase_Value_ItemID], axis=1)

# Rename dataframe and sort purchase count from highest to lowest
df_Items = df_Items.rename(columns={"SN":"Purchase Count", 
                                    "Price":"Item Price", 
                                    0:"Total Purchase Value"}).sort_values("Purchase Count", ascending=False)

#Format dataframe
df_Items['Item Price'] = df_Items['Item Price'].map('${:,.2f}'.format)
df_Items['Total Purchase Value'] = df_Items['Total Purchase Value'].map('${:,.2f}'.format)

# Keep the top 5 most popular items
df_MostPopular= df_Items[:5]

df_MostPopular
```




<div>
<style scoped>
    .dataframe tbody tr th:only-of-type {
        vertical-align: middle;
    }

    .dataframe tbody tr th {
        vertical-align: top;
    }

    .dataframe thead th {
        text-align: right;
    }
</style>
<table border="1" class="dataframe">
  <thead>
    <tr style="text-align: right;">
      <th></th>
      <th></th>
      <th>Purchase Count</th>
      <th>Item Price</th>
      <th>Total Purchase Value</th>
    </tr>
    <tr>
      <th>Item ID</th>
      <th>Item Name</th>
      <th></th>
      <th></th>
      <th></th>
    </tr>
  </thead>
  <tbody>
    <tr>
      <th>39</th>
      <th>Betrayal, Whisper of Grieving Widows</th>
      <td>11</td>
      <td>$2.35</td>
      <td>$25.85</td>
    </tr>
    <tr>
      <th>84</th>
      <th>Arcane Gem</th>
      <td>11</td>
      <td>$2.23</td>
      <td>$24.53</td>
    </tr>
    <tr>
      <th>31</th>
      <th>Trickster</th>
      <td>9</td>
      <td>$2.07</td>
      <td>$18.63</td>
    </tr>
    <tr>
      <th>175</th>
      <th>Woeful Adamantite Claymore</th>
      <td>9</td>
      <td>$1.24</td>
      <td>$11.16</td>
    </tr>
    <tr>
      <th>13</th>
      <th>Serenity</th>
      <td>9</td>
      <td>$1.49</td>
      <td>$13.41</td>
    </tr>
  </tbody>
</table>
</div>



## Most Profitable Items


```python
# Rename dataframe and sort purchase count from highest to lowest
df_Items['Total Purchase Value'] = df_Items['Total Purchase Value'].str.replace('$', '').astype('float64')


# Rename dataframe and sort purchase count from highest to lowest
df_ItemsProfit = df_Items.sort_values("Total Purchase Value", ascending=False)

df_ItemsProfit ['Total Purchase Value'] = df_ItemsProfit ['Total Purchase Value'].map('${:,.2f}'.format)

# Keep the top 5 most profitable items
df_MostProfitable= df_ItemsProfit [:5]

df_MostProfitable
```




<div>
<style scoped>
    .dataframe tbody tr th:only-of-type {
        vertical-align: middle;
    }

    .dataframe tbody tr th {
        vertical-align: top;
    }

    .dataframe thead th {
        text-align: right;
    }
</style>
<table border="1" class="dataframe">
  <thead>
    <tr style="text-align: right;">
      <th></th>
      <th></th>
      <th>Purchase Count</th>
      <th>Item Price</th>
      <th>Total Purchase Value</th>
    </tr>
    <tr>
      <th>Item ID</th>
      <th>Item Name</th>
      <th></th>
      <th></th>
      <th></th>
    </tr>
  </thead>
  <tbody>
    <tr>
      <th>34</th>
      <th>Retribution Axe</th>
      <td>9</td>
      <td>$4.14</td>
      <td>$37.26</td>
    </tr>
    <tr>
      <th>115</th>
      <th>Spectral Diamond Doomblade</th>
      <td>7</td>
      <td>$4.25</td>
      <td>$29.75</td>
    </tr>
    <tr>
      <th>32</th>
      <th>Orenmir</th>
      <td>6</td>
      <td>$4.95</td>
      <td>$29.70</td>
    </tr>
    <tr>
      <th>103</th>
      <th>Singed Scalpel</th>
      <td>6</td>
      <td>$4.87</td>
      <td>$29.22</td>
    </tr>
    <tr>
      <th>107</th>
      <th>Splitter, Foe Of Subtlety</th>
      <td>8</td>
      <td>$3.61</td>
      <td>$28.88</td>
    </tr>
  </tbody>
</table>
</div>


