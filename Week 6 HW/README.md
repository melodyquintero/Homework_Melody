
# WeatherPy


```python
# Dependencies
import matplotlib.pyplot as plt
import random
import requests
import urllib
import pandas as pd
import numpy as np
import openweathermapy.core as owm
from config import api_key
from citipy import citipy
```

## Generate Cities List


```python
# As latitudes ranged from -90 to 90, longitudes from -180 to 180,list the numbers in between them by o.1 difference.  

lat_range = list(np.arange(-90,90,0.1))
lon_range = list(np.arange(-180,180,0.2))
    #len(lat_range)

# select 1500 random samples to make sure my city samples > 500
latitude = random.sample(lat_range,1500)
longitude = random.sample(lon_range,1500)

coordinates = zip(latitude, longitude)

# use citypy to determine the name of the nearest city of the lat & lon provided
cities = []
for coordinate_pair in coordinates:
    lat, lon = coordinate_pair
    cities.append(citipy.nearest_city(lat, lon))
    
city_names = []
for city in cities:
    city_names.append(city.city_name)

# remove dublicate city names
city_names = list(set(city_names))

# make sure I have at least 500 city samples
len(city_names)
```




    616



## Perform API Calls


```python
settings = {"units": "imperial", "appid": api_key}
```


```python
# set up lists to hold reponse info
name = []
country = []
lat = []
lon = []
max_temp = []
humidity = []
clouds = []
wind_speed =[]

print("Beginning Data Retrieval")
print("-"*30)

# --------------------------------------------------------------------------
# Loop through the list of city names and perform requests on each city name
# ---------------------------------------------------------------------------

# set city number to count for the cities being requested
city_number = 0

for i in city_names:
    city_number +=1
    
    try:
        # print a log of each city as being processed with city number, city name and requested URL
        print(f"Processing Record {city_number} | {i}")
  
        query_url = f"http://api.openweathermap.org/data/2.5/weather?appid={api_key}&units=imperial&q="
        print(f"{query_url}{i.replace(' ', '%20')}")
        
        # try request response
        response = owm.get_current(i, **settings)
        
        name.append(response['name'])
        country.append(response['sys']['country'])
        lat.append(response['coord']['lat'])
        lon.append(response['coord']['lon'])
        max_temp.append(response['main']['temp_max'])
        humidity.append(response['main']['humidity'])
        clouds.append(response['clouds']['all'])
        wind_speed.append(response['wind']['speed'])
    
    except:
        
        # print out the city with HTTP error
        print(f"No record for city:{i}")
        continue
        
            
print("-"*30)        
print("Data Retrieval Complete")
print("-"*30)

```

    Beginning Data Retrieval
    ------------------------------
    Processing Record 1 | saint-pierre
    http://api.openweathermap.org/data/2.5/weather?appid=a412e057dbaa5b5779d43d4e78580b64&units=imperial&q=saint-pierre
    Processing Record 2 | warangal
    http://api.openweathermap.org/data/2.5/weather?appid=a412e057dbaa5b5779d43d4e78580b64&units=imperial&q=warangal
    Processing Record 3 | strezhevoy
    http://api.openweathermap.org/data/2.5/weather?appid=a412e057dbaa5b5779d43d4e78580b64&units=imperial&q=strezhevoy
    Processing Record 4 | guiratinga
    http://api.openweathermap.org/data/2.5/weather?appid=a412e057dbaa5b5779d43d4e78580b64&units=imperial&q=guiratinga
    Processing Record 5 | kristiinankaupunki
    http://api.openweathermap.org/data/2.5/weather?appid=a412e057dbaa5b5779d43d4e78580b64&units=imperial&q=kristiinankaupunki
    No record for city:kristiinankaupunki
    Processing Record 6 | muros
    http://api.openweathermap.org/data/2.5/weather?appid=a412e057dbaa5b5779d43d4e78580b64&units=imperial&q=muros
    Processing Record 7 | mayo
    http://api.openweathermap.org/data/2.5/weather?appid=a412e057dbaa5b5779d43d4e78580b64&units=imperial&q=mayo
    Processing Record 8 | mecca
    http://api.openweathermap.org/data/2.5/weather?appid=a412e057dbaa5b5779d43d4e78580b64&units=imperial&q=mecca
    Processing Record 9 | shelton
    http://api.openweathermap.org/data/2.5/weather?appid=a412e057dbaa5b5779d43d4e78580b64&units=imperial&q=shelton
    Processing Record 10 | manuk mangkaw
    http://api.openweathermap.org/data/2.5/weather?appid=a412e057dbaa5b5779d43d4e78580b64&units=imperial&q=manuk%20mangkaw
    Processing Record 11 | vaini
    http://api.openweathermap.org/data/2.5/weather?appid=a412e057dbaa5b5779d43d4e78580b64&units=imperial&q=vaini
    Processing Record 12 | provideniya
    http://api.openweathermap.org/data/2.5/weather?appid=a412e057dbaa5b5779d43d4e78580b64&units=imperial&q=provideniya
    Processing Record 13 | faya
    http://api.openweathermap.org/data/2.5/weather?appid=a412e057dbaa5b5779d43d4e78580b64&units=imperial&q=faya
    Processing Record 14 | seybaplaya
    http://api.openweathermap.org/data/2.5/weather?appid=a412e057dbaa5b5779d43d4e78580b64&units=imperial&q=seybaplaya
    Processing Record 15 | garowe
    http://api.openweathermap.org/data/2.5/weather?appid=a412e057dbaa5b5779d43d4e78580b64&units=imperial&q=garowe
    Processing Record 16 | mullaitivu
    http://api.openweathermap.org/data/2.5/weather?appid=a412e057dbaa5b5779d43d4e78580b64&units=imperial&q=mullaitivu
    No record for city:mullaitivu
    Processing Record 17 | rio verde de mato grosso
    http://api.openweathermap.org/data/2.5/weather?appid=a412e057dbaa5b5779d43d4e78580b64&units=imperial&q=rio%20verde%20de%20mato%20grosso
    Processing Record 18 | road town
    http://api.openweathermap.org/data/2.5/weather?appid=a412e057dbaa5b5779d43d4e78580b64&units=imperial&q=road%20town
    Processing Record 19 | vila velha
    http://api.openweathermap.org/data/2.5/weather?appid=a412e057dbaa5b5779d43d4e78580b64&units=imperial&q=vila%20velha
    Processing Record 20 | los llanos de aridane
    http://api.openweathermap.org/data/2.5/weather?appid=a412e057dbaa5b5779d43d4e78580b64&units=imperial&q=los%20llanos%20de%20aridane
    Processing Record 21 | lorengau
    http://api.openweathermap.org/data/2.5/weather?appid=a412e057dbaa5b5779d43d4e78580b64&units=imperial&q=lorengau
    Processing Record 22 | cabatuan
    http://api.openweathermap.org/data/2.5/weather?appid=a412e057dbaa5b5779d43d4e78580b64&units=imperial&q=cabatuan
    Processing Record 23 | visimo-utkinsk
    http://api.openweathermap.org/data/2.5/weather?appid=a412e057dbaa5b5779d43d4e78580b64&units=imperial&q=visimo-utkinsk
    No record for city:visimo-utkinsk
    Processing Record 24 | mentok
    http://api.openweathermap.org/data/2.5/weather?appid=a412e057dbaa5b5779d43d4e78580b64&units=imperial&q=mentok
    No record for city:mentok
    Processing Record 25 | abu dhabi
    http://api.openweathermap.org/data/2.5/weather?appid=a412e057dbaa5b5779d43d4e78580b64&units=imperial&q=abu%20dhabi
    Processing Record 26 | halifax
    http://api.openweathermap.org/data/2.5/weather?appid=a412e057dbaa5b5779d43d4e78580b64&units=imperial&q=halifax
    Processing Record 27 | manzhouli
    http://api.openweathermap.org/data/2.5/weather?appid=a412e057dbaa5b5779d43d4e78580b64&units=imperial&q=manzhouli
    Processing Record 28 | nicoya
    http://api.openweathermap.org/data/2.5/weather?appid=a412e057dbaa5b5779d43d4e78580b64&units=imperial&q=nicoya
    Processing Record 29 | cherskiy
    http://api.openweathermap.org/data/2.5/weather?appid=a412e057dbaa5b5779d43d4e78580b64&units=imperial&q=cherskiy
    Processing Record 30 | castro
    http://api.openweathermap.org/data/2.5/weather?appid=a412e057dbaa5b5779d43d4e78580b64&units=imperial&q=castro
    Processing Record 31 | phan rang
    http://api.openweathermap.org/data/2.5/weather?appid=a412e057dbaa5b5779d43d4e78580b64&units=imperial&q=phan%20rang
    No record for city:phan rang
    Processing Record 32 | springbok
    http://api.openweathermap.org/data/2.5/weather?appid=a412e057dbaa5b5779d43d4e78580b64&units=imperial&q=springbok
    Processing Record 33 | bubaque
    http://api.openweathermap.org/data/2.5/weather?appid=a412e057dbaa5b5779d43d4e78580b64&units=imperial&q=bubaque
    Processing Record 34 | kushva
    http://api.openweathermap.org/data/2.5/weather?appid=a412e057dbaa5b5779d43d4e78580b64&units=imperial&q=kushva
    Processing Record 35 | port lincoln
    http://api.openweathermap.org/data/2.5/weather?appid=a412e057dbaa5b5779d43d4e78580b64&units=imperial&q=port%20lincoln
    Processing Record 36 | stokmarknes
    http://api.openweathermap.org/data/2.5/weather?appid=a412e057dbaa5b5779d43d4e78580b64&units=imperial&q=stokmarknes
    Processing Record 37 | mataura
    http://api.openweathermap.org/data/2.5/weather?appid=a412e057dbaa5b5779d43d4e78580b64&units=imperial&q=mataura
    Processing Record 38 | airai
    http://api.openweathermap.org/data/2.5/weather?appid=a412e057dbaa5b5779d43d4e78580b64&units=imperial&q=airai
    Processing Record 39 | tabiauea
    http://api.openweathermap.org/data/2.5/weather?appid=a412e057dbaa5b5779d43d4e78580b64&units=imperial&q=tabiauea
    No record for city:tabiauea
    Processing Record 40 | klaebu
    http://api.openweathermap.org/data/2.5/weather?appid=a412e057dbaa5b5779d43d4e78580b64&units=imperial&q=klaebu
    Processing Record 41 | qui nhon
    http://api.openweathermap.org/data/2.5/weather?appid=a412e057dbaa5b5779d43d4e78580b64&units=imperial&q=qui%20nhon
    No record for city:qui nhon
    Processing Record 42 | palampur
    http://api.openweathermap.org/data/2.5/weather?appid=a412e057dbaa5b5779d43d4e78580b64&units=imperial&q=palampur
    Processing Record 43 | iralaya
    http://api.openweathermap.org/data/2.5/weather?appid=a412e057dbaa5b5779d43d4e78580b64&units=imperial&q=iralaya
    Processing Record 44 | inhumas
    http://api.openweathermap.org/data/2.5/weather?appid=a412e057dbaa5b5779d43d4e78580b64&units=imperial&q=inhumas
    Processing Record 45 | coquimbo
    http://api.openweathermap.org/data/2.5/weather?appid=a412e057dbaa5b5779d43d4e78580b64&units=imperial&q=coquimbo
    Processing Record 46 | jamestown
    http://api.openweathermap.org/data/2.5/weather?appid=a412e057dbaa5b5779d43d4e78580b64&units=imperial&q=jamestown
    Processing Record 47 | teguldet
    http://api.openweathermap.org/data/2.5/weather?appid=a412e057dbaa5b5779d43d4e78580b64&units=imperial&q=teguldet
    Processing Record 48 | amazar
    http://api.openweathermap.org/data/2.5/weather?appid=a412e057dbaa5b5779d43d4e78580b64&units=imperial&q=amazar
    Processing Record 49 | east london
    http://api.openweathermap.org/data/2.5/weather?appid=a412e057dbaa5b5779d43d4e78580b64&units=imperial&q=east%20london
    Processing Record 50 | christchurch
    http://api.openweathermap.org/data/2.5/weather?appid=a412e057dbaa5b5779d43d4e78580b64&units=imperial&q=christchurch
    Processing Record 51 | namibe
    http://api.openweathermap.org/data/2.5/weather?appid=a412e057dbaa5b5779d43d4e78580b64&units=imperial&q=namibe
    Processing Record 52 | longyearbyen
    http://api.openweathermap.org/data/2.5/weather?appid=a412e057dbaa5b5779d43d4e78580b64&units=imperial&q=longyearbyen
    Processing Record 53 | sao felix do xingu
    http://api.openweathermap.org/data/2.5/weather?appid=a412e057dbaa5b5779d43d4e78580b64&units=imperial&q=sao%20felix%20do%20xingu
    Processing Record 54 | bandarbeyla
    http://api.openweathermap.org/data/2.5/weather?appid=a412e057dbaa5b5779d43d4e78580b64&units=imperial&q=bandarbeyla
    Processing Record 55 | luau
    http://api.openweathermap.org/data/2.5/weather?appid=a412e057dbaa5b5779d43d4e78580b64&units=imperial&q=luau
    Processing Record 56 | boca do acre
    http://api.openweathermap.org/data/2.5/weather?appid=a412e057dbaa5b5779d43d4e78580b64&units=imperial&q=boca%20do%20acre
    Processing Record 57 | san carlos de bariloche
    http://api.openweathermap.org/data/2.5/weather?appid=a412e057dbaa5b5779d43d4e78580b64&units=imperial&q=san%20carlos%20de%20bariloche
    Processing Record 58 | atambua
    http://api.openweathermap.org/data/2.5/weather?appid=a412e057dbaa5b5779d43d4e78580b64&units=imperial&q=atambua
    Processing Record 59 | houma
    http://api.openweathermap.org/data/2.5/weather?appid=a412e057dbaa5b5779d43d4e78580b64&units=imperial&q=houma
    Processing Record 60 | torbay
    http://api.openweathermap.org/data/2.5/weather?appid=a412e057dbaa5b5779d43d4e78580b64&units=imperial&q=torbay
    Processing Record 61 | chokurdakh
    http://api.openweathermap.org/data/2.5/weather?appid=a412e057dbaa5b5779d43d4e78580b64&units=imperial&q=chokurdakh
    Processing Record 62 | lasa
    http://api.openweathermap.org/data/2.5/weather?appid=a412e057dbaa5b5779d43d4e78580b64&units=imperial&q=lasa
    Processing Record 63 | marawi
    http://api.openweathermap.org/data/2.5/weather?appid=a412e057dbaa5b5779d43d4e78580b64&units=imperial&q=marawi
    Processing Record 64 | salalah
    http://api.openweathermap.org/data/2.5/weather?appid=a412e057dbaa5b5779d43d4e78580b64&units=imperial&q=salalah
    Processing Record 65 | lavrentiya
    http://api.openweathermap.org/data/2.5/weather?appid=a412e057dbaa5b5779d43d4e78580b64&units=imperial&q=lavrentiya
    Processing Record 66 | vanimo
    http://api.openweathermap.org/data/2.5/weather?appid=a412e057dbaa5b5779d43d4e78580b64&units=imperial&q=vanimo
    Processing Record 67 | ati
    http://api.openweathermap.org/data/2.5/weather?appid=a412e057dbaa5b5779d43d4e78580b64&units=imperial&q=ati
    Processing Record 68 | kavieng
    http://api.openweathermap.org/data/2.5/weather?appid=a412e057dbaa5b5779d43d4e78580b64&units=imperial&q=kavieng
    Processing Record 69 | payo
    http://api.openweathermap.org/data/2.5/weather?appid=a412e057dbaa5b5779d43d4e78580b64&units=imperial&q=payo
    Processing Record 70 | dali
    http://api.openweathermap.org/data/2.5/weather?appid=a412e057dbaa5b5779d43d4e78580b64&units=imperial&q=dali
    Processing Record 71 | bethel
    http://api.openweathermap.org/data/2.5/weather?appid=a412e057dbaa5b5779d43d4e78580b64&units=imperial&q=bethel
    Processing Record 72 | gumushane
    http://api.openweathermap.org/data/2.5/weather?appid=a412e057dbaa5b5779d43d4e78580b64&units=imperial&q=gumushane
    No record for city:gumushane
    Processing Record 73 | cabildo
    http://api.openweathermap.org/data/2.5/weather?appid=a412e057dbaa5b5779d43d4e78580b64&units=imperial&q=cabildo
    Processing Record 74 | touros
    http://api.openweathermap.org/data/2.5/weather?appid=a412e057dbaa5b5779d43d4e78580b64&units=imperial&q=touros
    Processing Record 75 | sorvag
    http://api.openweathermap.org/data/2.5/weather?appid=a412e057dbaa5b5779d43d4e78580b64&units=imperial&q=sorvag
    No record for city:sorvag
    Processing Record 76 | new norfolk
    http://api.openweathermap.org/data/2.5/weather?appid=a412e057dbaa5b5779d43d4e78580b64&units=imperial&q=new%20norfolk
    Processing Record 77 | mayor pablo lagerenza
    http://api.openweathermap.org/data/2.5/weather?appid=a412e057dbaa5b5779d43d4e78580b64&units=imperial&q=mayor%20pablo%20lagerenza
    Processing Record 78 | alto araguaia
    http://api.openweathermap.org/data/2.5/weather?appid=a412e057dbaa5b5779d43d4e78580b64&units=imperial&q=alto%20araguaia
    Processing Record 79 | aswan
    http://api.openweathermap.org/data/2.5/weather?appid=a412e057dbaa5b5779d43d4e78580b64&units=imperial&q=aswan
    Processing Record 80 | hermanus
    http://api.openweathermap.org/data/2.5/weather?appid=a412e057dbaa5b5779d43d4e78580b64&units=imperial&q=hermanus
    Processing Record 81 | port macquarie
    http://api.openweathermap.org/data/2.5/weather?appid=a412e057dbaa5b5779d43d4e78580b64&units=imperial&q=port%20macquarie
    Processing Record 82 | camopi
    http://api.openweathermap.org/data/2.5/weather?appid=a412e057dbaa5b5779d43d4e78580b64&units=imperial&q=camopi
    Processing Record 83 | berbera
    http://api.openweathermap.org/data/2.5/weather?appid=a412e057dbaa5b5779d43d4e78580b64&units=imperial&q=berbera
    No record for city:berbera
    Processing Record 84 | flinders
    http://api.openweathermap.org/data/2.5/weather?appid=a412e057dbaa5b5779d43d4e78580b64&units=imperial&q=flinders
    Processing Record 85 | acapulco
    http://api.openweathermap.org/data/2.5/weather?appid=a412e057dbaa5b5779d43d4e78580b64&units=imperial&q=acapulco
    Processing Record 86 | kachikau
    http://api.openweathermap.org/data/2.5/weather?appid=a412e057dbaa5b5779d43d4e78580b64&units=imperial&q=kachikau
    No record for city:kachikau
    Processing Record 87 | zarand
    http://api.openweathermap.org/data/2.5/weather?appid=a412e057dbaa5b5779d43d4e78580b64&units=imperial&q=zarand
    Processing Record 88 | ketchikan
    http://api.openweathermap.org/data/2.5/weather?appid=a412e057dbaa5b5779d43d4e78580b64&units=imperial&q=ketchikan
    Processing Record 89 | lebu
    http://api.openweathermap.org/data/2.5/weather?appid=a412e057dbaa5b5779d43d4e78580b64&units=imperial&q=lebu
    Processing Record 90 | mafinga
    http://api.openweathermap.org/data/2.5/weather?appid=a412e057dbaa5b5779d43d4e78580b64&units=imperial&q=mafinga
    No record for city:mafinga
    Processing Record 91 | tasiilaq
    http://api.openweathermap.org/data/2.5/weather?appid=a412e057dbaa5b5779d43d4e78580b64&units=imperial&q=tasiilaq
    Processing Record 92 | namatanai
    http://api.openweathermap.org/data/2.5/weather?appid=a412e057dbaa5b5779d43d4e78580b64&units=imperial&q=namatanai
    Processing Record 93 | el vigia
    http://api.openweathermap.org/data/2.5/weather?appid=a412e057dbaa5b5779d43d4e78580b64&units=imperial&q=el%20vigia
    Processing Record 94 | pleasantville
    http://api.openweathermap.org/data/2.5/weather?appid=a412e057dbaa5b5779d43d4e78580b64&units=imperial&q=pleasantville
    Processing Record 95 | tuatapere
    http://api.openweathermap.org/data/2.5/weather?appid=a412e057dbaa5b5779d43d4e78580b64&units=imperial&q=tuatapere
    Processing Record 96 | puerto del rosario
    http://api.openweathermap.org/data/2.5/weather?appid=a412e057dbaa5b5779d43d4e78580b64&units=imperial&q=puerto%20del%20rosario
    Processing Record 97 | srednekolymsk
    http://api.openweathermap.org/data/2.5/weather?appid=a412e057dbaa5b5779d43d4e78580b64&units=imperial&q=srednekolymsk
    Processing Record 98 | svetlaya
    http://api.openweathermap.org/data/2.5/weather?appid=a412e057dbaa5b5779d43d4e78580b64&units=imperial&q=svetlaya
    Processing Record 99 | krasavino
    http://api.openweathermap.org/data/2.5/weather?appid=a412e057dbaa5b5779d43d4e78580b64&units=imperial&q=krasavino
    Processing Record 100 | trairi
    http://api.openweathermap.org/data/2.5/weather?appid=a412e057dbaa5b5779d43d4e78580b64&units=imperial&q=trairi
    Processing Record 101 | port hedland
    http://api.openweathermap.org/data/2.5/weather?appid=a412e057dbaa5b5779d43d4e78580b64&units=imperial&q=port%20hedland
    Processing Record 102 | la asuncion
    http://api.openweathermap.org/data/2.5/weather?appid=a412e057dbaa5b5779d43d4e78580b64&units=imperial&q=la%20asuncion
    Processing Record 103 | asau
    http://api.openweathermap.org/data/2.5/weather?appid=a412e057dbaa5b5779d43d4e78580b64&units=imperial&q=asau
    No record for city:asau
    Processing Record 104 | shenjiamen
    http://api.openweathermap.org/data/2.5/weather?appid=a412e057dbaa5b5779d43d4e78580b64&units=imperial&q=shenjiamen
    Processing Record 105 | kadoma
    http://api.openweathermap.org/data/2.5/weather?appid=a412e057dbaa5b5779d43d4e78580b64&units=imperial&q=kadoma
    Processing Record 106 | sitka
    http://api.openweathermap.org/data/2.5/weather?appid=a412e057dbaa5b5779d43d4e78580b64&units=imperial&q=sitka
    Processing Record 107 | bundaberg
    http://api.openweathermap.org/data/2.5/weather?appid=a412e057dbaa5b5779d43d4e78580b64&units=imperial&q=bundaberg
    Processing Record 108 | lompoc
    http://api.openweathermap.org/data/2.5/weather?appid=a412e057dbaa5b5779d43d4e78580b64&units=imperial&q=lompoc
    Processing Record 109 | amderma
    http://api.openweathermap.org/data/2.5/weather?appid=a412e057dbaa5b5779d43d4e78580b64&units=imperial&q=amderma
    No record for city:amderma
    Processing Record 110 | loviisa
    http://api.openweathermap.org/data/2.5/weather?appid=a412e057dbaa5b5779d43d4e78580b64&units=imperial&q=loviisa
    Processing Record 111 | kharp
    http://api.openweathermap.org/data/2.5/weather?appid=a412e057dbaa5b5779d43d4e78580b64&units=imperial&q=kharp
    Processing Record 112 | upernavik
    http://api.openweathermap.org/data/2.5/weather?appid=a412e057dbaa5b5779d43d4e78580b64&units=imperial&q=upernavik
    Processing Record 113 | disa
    http://api.openweathermap.org/data/2.5/weather?appid=a412e057dbaa5b5779d43d4e78580b64&units=imperial&q=disa
    Processing Record 114 | san luis
    http://api.openweathermap.org/data/2.5/weather?appid=a412e057dbaa5b5779d43d4e78580b64&units=imperial&q=san%20luis
    Processing Record 115 | kysyl-syr
    http://api.openweathermap.org/data/2.5/weather?appid=a412e057dbaa5b5779d43d4e78580b64&units=imperial&q=kysyl-syr
    Processing Record 116 | santa cruz
    http://api.openweathermap.org/data/2.5/weather?appid=a412e057dbaa5b5779d43d4e78580b64&units=imperial&q=santa%20cruz
    Processing Record 117 | la ronge
    http://api.openweathermap.org/data/2.5/weather?appid=a412e057dbaa5b5779d43d4e78580b64&units=imperial&q=la%20ronge
    Processing Record 118 | umzimvubu
    http://api.openweathermap.org/data/2.5/weather?appid=a412e057dbaa5b5779d43d4e78580b64&units=imperial&q=umzimvubu
    No record for city:umzimvubu
    Processing Record 119 | mys shmidta
    http://api.openweathermap.org/data/2.5/weather?appid=a412e057dbaa5b5779d43d4e78580b64&units=imperial&q=mys%20shmidta
    No record for city:mys shmidta
    Processing Record 120 | tocopilla
    http://api.openweathermap.org/data/2.5/weather?appid=a412e057dbaa5b5779d43d4e78580b64&units=imperial&q=tocopilla
    Processing Record 121 | ust-kamchatsk
    http://api.openweathermap.org/data/2.5/weather?appid=a412e057dbaa5b5779d43d4e78580b64&units=imperial&q=ust-kamchatsk
    No record for city:ust-kamchatsk
    Processing Record 122 | hovd
    http://api.openweathermap.org/data/2.5/weather?appid=a412e057dbaa5b5779d43d4e78580b64&units=imperial&q=hovd
    Processing Record 123 | chute-aux-outardes
    http://api.openweathermap.org/data/2.5/weather?appid=a412e057dbaa5b5779d43d4e78580b64&units=imperial&q=chute-aux-outardes
    Processing Record 124 | laguna
    http://api.openweathermap.org/data/2.5/weather?appid=a412e057dbaa5b5779d43d4e78580b64&units=imperial&q=laguna
    Processing Record 125 | jorpeland
    http://api.openweathermap.org/data/2.5/weather?appid=a412e057dbaa5b5779d43d4e78580b64&units=imperial&q=jorpeland
    Processing Record 126 | moose factory
    http://api.openweathermap.org/data/2.5/weather?appid=a412e057dbaa5b5779d43d4e78580b64&units=imperial&q=moose%20factory
    Processing Record 127 | namangan
    http://api.openweathermap.org/data/2.5/weather?appid=a412e057dbaa5b5779d43d4e78580b64&units=imperial&q=namangan
    Processing Record 128 | attawapiskat
    http://api.openweathermap.org/data/2.5/weather?appid=a412e057dbaa5b5779d43d4e78580b64&units=imperial&q=attawapiskat
    No record for city:attawapiskat
    Processing Record 129 | mount gambier
    http://api.openweathermap.org/data/2.5/weather?appid=a412e057dbaa5b5779d43d4e78580b64&units=imperial&q=mount%20gambier
    Processing Record 130 | souillac
    http://api.openweathermap.org/data/2.5/weather?appid=a412e057dbaa5b5779d43d4e78580b64&units=imperial&q=souillac
    Processing Record 131 | beisfjord
    http://api.openweathermap.org/data/2.5/weather?appid=a412e057dbaa5b5779d43d4e78580b64&units=imperial&q=beisfjord
    Processing Record 132 | sentyabrskiy
    http://api.openweathermap.org/data/2.5/weather?appid=a412e057dbaa5b5779d43d4e78580b64&units=imperial&q=sentyabrskiy
    No record for city:sentyabrskiy
    Processing Record 133 | furstenwalde
    http://api.openweathermap.org/data/2.5/weather?appid=a412e057dbaa5b5779d43d4e78580b64&units=imperial&q=furstenwalde
    Processing Record 134 | talnakh
    http://api.openweathermap.org/data/2.5/weather?appid=a412e057dbaa5b5779d43d4e78580b64&units=imperial&q=talnakh
    Processing Record 135 | xichang
    http://api.openweathermap.org/data/2.5/weather?appid=a412e057dbaa5b5779d43d4e78580b64&units=imperial&q=xichang
    Processing Record 136 | elizabeth city
    http://api.openweathermap.org/data/2.5/weather?appid=a412e057dbaa5b5779d43d4e78580b64&units=imperial&q=elizabeth%20city
    Processing Record 137 | fort nelson
    http://api.openweathermap.org/data/2.5/weather?appid=a412e057dbaa5b5779d43d4e78580b64&units=imperial&q=fort%20nelson
    Processing Record 138 | dongsheng
    http://api.openweathermap.org/data/2.5/weather?appid=a412e057dbaa5b5779d43d4e78580b64&units=imperial&q=dongsheng
    Processing Record 139 | ipixuna
    http://api.openweathermap.org/data/2.5/weather?appid=a412e057dbaa5b5779d43d4e78580b64&units=imperial&q=ipixuna
    Processing Record 140 | cidreira
    http://api.openweathermap.org/data/2.5/weather?appid=a412e057dbaa5b5779d43d4e78580b64&units=imperial&q=cidreira
    Processing Record 141 | mandalgovi
    http://api.openweathermap.org/data/2.5/weather?appid=a412e057dbaa5b5779d43d4e78580b64&units=imperial&q=mandalgovi
    Processing Record 142 | vaitupu
    http://api.openweathermap.org/data/2.5/weather?appid=a412e057dbaa5b5779d43d4e78580b64&units=imperial&q=vaitupu
    No record for city:vaitupu
    Processing Record 143 | plettenberg bay
    http://api.openweathermap.org/data/2.5/weather?appid=a412e057dbaa5b5779d43d4e78580b64&units=imperial&q=plettenberg%20bay
    Processing Record 144 | tianjin
    http://api.openweathermap.org/data/2.5/weather?appid=a412e057dbaa5b5779d43d4e78580b64&units=imperial&q=tianjin
    Processing Record 145 | pevek
    http://api.openweathermap.org/data/2.5/weather?appid=a412e057dbaa5b5779d43d4e78580b64&units=imperial&q=pevek
    Processing Record 146 | louviers
    http://api.openweathermap.org/data/2.5/weather?appid=a412e057dbaa5b5779d43d4e78580b64&units=imperial&q=louviers
    Processing Record 147 | paramonga
    http://api.openweathermap.org/data/2.5/weather?appid=a412e057dbaa5b5779d43d4e78580b64&units=imperial&q=paramonga
    Processing Record 148 | belushya guba
    http://api.openweathermap.org/data/2.5/weather?appid=a412e057dbaa5b5779d43d4e78580b64&units=imperial&q=belushya%20guba
    No record for city:belushya guba
    Processing Record 149 | nikel
    http://api.openweathermap.org/data/2.5/weather?appid=a412e057dbaa5b5779d43d4e78580b64&units=imperial&q=nikel
    Processing Record 150 | padampur
    http://api.openweathermap.org/data/2.5/weather?appid=a412e057dbaa5b5779d43d4e78580b64&units=imperial&q=padampur
    Processing Record 151 | waingapu
    http://api.openweathermap.org/data/2.5/weather?appid=a412e057dbaa5b5779d43d4e78580b64&units=imperial&q=waingapu
    Processing Record 152 | colares
    http://api.openweathermap.org/data/2.5/weather?appid=a412e057dbaa5b5779d43d4e78580b64&units=imperial&q=colares
    Processing Record 153 | dolgoprudnyy
    http://api.openweathermap.org/data/2.5/weather?appid=a412e057dbaa5b5779d43d4e78580b64&units=imperial&q=dolgoprudnyy
    Processing Record 154 | kaitangata
    http://api.openweathermap.org/data/2.5/weather?appid=a412e057dbaa5b5779d43d4e78580b64&units=imperial&q=kaitangata
    Processing Record 155 | nongan
    http://api.openweathermap.org/data/2.5/weather?appid=a412e057dbaa5b5779d43d4e78580b64&units=imperial&q=nongan
    Processing Record 156 | tecpan
    http://api.openweathermap.org/data/2.5/weather?appid=a412e057dbaa5b5779d43d4e78580b64&units=imperial&q=tecpan
    Processing Record 157 | veraval
    http://api.openweathermap.org/data/2.5/weather?appid=a412e057dbaa5b5779d43d4e78580b64&units=imperial&q=veraval
    Processing Record 158 | tomatlan
    http://api.openweathermap.org/data/2.5/weather?appid=a412e057dbaa5b5779d43d4e78580b64&units=imperial&q=tomatlan
    Processing Record 159 | nanortalik
    http://api.openweathermap.org/data/2.5/weather?appid=a412e057dbaa5b5779d43d4e78580b64&units=imperial&q=nanortalik
    Processing Record 160 | mogok
    http://api.openweathermap.org/data/2.5/weather?appid=a412e057dbaa5b5779d43d4e78580b64&units=imperial&q=mogok
    Processing Record 161 | sao joao da barra
    http://api.openweathermap.org/data/2.5/weather?appid=a412e057dbaa5b5779d43d4e78580b64&units=imperial&q=sao%20joao%20da%20barra
    Processing Record 162 | eureka
    http://api.openweathermap.org/data/2.5/weather?appid=a412e057dbaa5b5779d43d4e78580b64&units=imperial&q=eureka
    Processing Record 163 | plattsburgh
    http://api.openweathermap.org/data/2.5/weather?appid=a412e057dbaa5b5779d43d4e78580b64&units=imperial&q=plattsburgh
    Processing Record 164 | severobaykalsk
    http://api.openweathermap.org/data/2.5/weather?appid=a412e057dbaa5b5779d43d4e78580b64&units=imperial&q=severobaykalsk
    Processing Record 165 | belaya gora
    http://api.openweathermap.org/data/2.5/weather?appid=a412e057dbaa5b5779d43d4e78580b64&units=imperial&q=belaya%20gora
    Processing Record 166 | mocambique
    http://api.openweathermap.org/data/2.5/weather?appid=a412e057dbaa5b5779d43d4e78580b64&units=imperial&q=mocambique
    No record for city:mocambique
    Processing Record 167 | ilulissat
    http://api.openweathermap.org/data/2.5/weather?appid=a412e057dbaa5b5779d43d4e78580b64&units=imperial&q=ilulissat
    Processing Record 168 | avera
    http://api.openweathermap.org/data/2.5/weather?appid=a412e057dbaa5b5779d43d4e78580b64&units=imperial&q=avera
    Processing Record 169 | kiunga
    http://api.openweathermap.org/data/2.5/weather?appid=a412e057dbaa5b5779d43d4e78580b64&units=imperial&q=kiunga
    Processing Record 170 | ancud
    http://api.openweathermap.org/data/2.5/weather?appid=a412e057dbaa5b5779d43d4e78580b64&units=imperial&q=ancud
    Processing Record 171 | lensk
    http://api.openweathermap.org/data/2.5/weather?appid=a412e057dbaa5b5779d43d4e78580b64&units=imperial&q=lensk
    Processing Record 172 | lamar
    http://api.openweathermap.org/data/2.5/weather?appid=a412e057dbaa5b5779d43d4e78580b64&units=imperial&q=lamar
    Processing Record 173 | lata
    http://api.openweathermap.org/data/2.5/weather?appid=a412e057dbaa5b5779d43d4e78580b64&units=imperial&q=lata
    Processing Record 174 | bandar
    http://api.openweathermap.org/data/2.5/weather?appid=a412e057dbaa5b5779d43d4e78580b64&units=imperial&q=bandar
    Processing Record 175 | seoul
    http://api.openweathermap.org/data/2.5/weather?appid=a412e057dbaa5b5779d43d4e78580b64&units=imperial&q=seoul
    Processing Record 176 | port moresby
    http://api.openweathermap.org/data/2.5/weather?appid=a412e057dbaa5b5779d43d4e78580b64&units=imperial&q=port%20moresby
    Processing Record 177 | rorvik
    http://api.openweathermap.org/data/2.5/weather?appid=a412e057dbaa5b5779d43d4e78580b64&units=imperial&q=rorvik
    Processing Record 178 | khatanga
    http://api.openweathermap.org/data/2.5/weather?appid=a412e057dbaa5b5779d43d4e78580b64&units=imperial&q=khatanga
    Processing Record 179 | petrozavodsk
    http://api.openweathermap.org/data/2.5/weather?appid=a412e057dbaa5b5779d43d4e78580b64&units=imperial&q=petrozavodsk
    Processing Record 180 | grindavik
    http://api.openweathermap.org/data/2.5/weather?appid=a412e057dbaa5b5779d43d4e78580b64&units=imperial&q=grindavik
    Processing Record 181 | ushuaia
    http://api.openweathermap.org/data/2.5/weather?appid=a412e057dbaa5b5779d43d4e78580b64&units=imperial&q=ushuaia
    Processing Record 182 | kemin
    http://api.openweathermap.org/data/2.5/weather?appid=a412e057dbaa5b5779d43d4e78580b64&units=imperial&q=kemin
    Processing Record 183 | umm lajj
    http://api.openweathermap.org/data/2.5/weather?appid=a412e057dbaa5b5779d43d4e78580b64&units=imperial&q=umm%20lajj
    Processing Record 184 | tilichiki
    http://api.openweathermap.org/data/2.5/weather?appid=a412e057dbaa5b5779d43d4e78580b64&units=imperial&q=tilichiki
    Processing Record 185 | uthal
    http://api.openweathermap.org/data/2.5/weather?appid=a412e057dbaa5b5779d43d4e78580b64&units=imperial&q=uthal
    Processing Record 186 | boyolangu
    http://api.openweathermap.org/data/2.5/weather?appid=a412e057dbaa5b5779d43d4e78580b64&units=imperial&q=boyolangu
    Processing Record 187 | whyalla
    http://api.openweathermap.org/data/2.5/weather?appid=a412e057dbaa5b5779d43d4e78580b64&units=imperial&q=whyalla
    Processing Record 188 | brae
    http://api.openweathermap.org/data/2.5/weather?appid=a412e057dbaa5b5779d43d4e78580b64&units=imperial&q=brae
    Processing Record 189 | laerdalsoyri
    http://api.openweathermap.org/data/2.5/weather?appid=a412e057dbaa5b5779d43d4e78580b64&units=imperial&q=laerdalsoyri
    Processing Record 190 | victoria
    http://api.openweathermap.org/data/2.5/weather?appid=a412e057dbaa5b5779d43d4e78580b64&units=imperial&q=victoria
    Processing Record 191 | zakamensk
    http://api.openweathermap.org/data/2.5/weather?appid=a412e057dbaa5b5779d43d4e78580b64&units=imperial&q=zakamensk
    Processing Record 192 | hihifo
    http://api.openweathermap.org/data/2.5/weather?appid=a412e057dbaa5b5779d43d4e78580b64&units=imperial&q=hihifo
    No record for city:hihifo
    Processing Record 193 | atuona
    http://api.openweathermap.org/data/2.5/weather?appid=a412e057dbaa5b5779d43d4e78580b64&units=imperial&q=atuona
    Processing Record 194 | arraial do cabo
    http://api.openweathermap.org/data/2.5/weather?appid=a412e057dbaa5b5779d43d4e78580b64&units=imperial&q=arraial%20do%20cabo
    Processing Record 195 | ko samui
    http://api.openweathermap.org/data/2.5/weather?appid=a412e057dbaa5b5779d43d4e78580b64&units=imperial&q=ko%20samui
    Processing Record 196 | high level
    http://api.openweathermap.org/data/2.5/weather?appid=a412e057dbaa5b5779d43d4e78580b64&units=imperial&q=high%20level
    Processing Record 197 | korla
    http://api.openweathermap.org/data/2.5/weather?appid=a412e057dbaa5b5779d43d4e78580b64&units=imperial&q=korla
    No record for city:korla
    Processing Record 198 | kupang
    http://api.openweathermap.org/data/2.5/weather?appid=a412e057dbaa5b5779d43d4e78580b64&units=imperial&q=kupang
    Processing Record 199 | shaunavon
    http://api.openweathermap.org/data/2.5/weather?appid=a412e057dbaa5b5779d43d4e78580b64&units=imperial&q=shaunavon
    Processing Record 200 | suntar
    http://api.openweathermap.org/data/2.5/weather?appid=a412e057dbaa5b5779d43d4e78580b64&units=imperial&q=suntar
    Processing Record 201 | anda
    http://api.openweathermap.org/data/2.5/weather?appid=a412e057dbaa5b5779d43d4e78580b64&units=imperial&q=anda
    Processing Record 202 | katherine
    http://api.openweathermap.org/data/2.5/weather?appid=a412e057dbaa5b5779d43d4e78580b64&units=imperial&q=katherine
    Processing Record 203 | kyshtovka
    http://api.openweathermap.org/data/2.5/weather?appid=a412e057dbaa5b5779d43d4e78580b64&units=imperial&q=kyshtovka
    Processing Record 204 | svetlogorsk
    http://api.openweathermap.org/data/2.5/weather?appid=a412e057dbaa5b5779d43d4e78580b64&units=imperial&q=svetlogorsk
    Processing Record 205 | guhagar
    http://api.openweathermap.org/data/2.5/weather?appid=a412e057dbaa5b5779d43d4e78580b64&units=imperial&q=guhagar
    Processing Record 206 | dingle
    http://api.openweathermap.org/data/2.5/weather?appid=a412e057dbaa5b5779d43d4e78580b64&units=imperial&q=dingle
    Processing Record 207 | bad bevensen
    http://api.openweathermap.org/data/2.5/weather?appid=a412e057dbaa5b5779d43d4e78580b64&units=imperial&q=bad%20bevensen
    Processing Record 208 | muroto
    http://api.openweathermap.org/data/2.5/weather?appid=a412e057dbaa5b5779d43d4e78580b64&units=imperial&q=muroto
    Processing Record 209 | zyryanka
    http://api.openweathermap.org/data/2.5/weather?appid=a412e057dbaa5b5779d43d4e78580b64&units=imperial&q=zyryanka
    Processing Record 210 | mehamn
    http://api.openweathermap.org/data/2.5/weather?appid=a412e057dbaa5b5779d43d4e78580b64&units=imperial&q=mehamn
    Processing Record 211 | vardo
    http://api.openweathermap.org/data/2.5/weather?appid=a412e057dbaa5b5779d43d4e78580b64&units=imperial&q=vardo
    Processing Record 212 | lyngseidet
    http://api.openweathermap.org/data/2.5/weather?appid=a412e057dbaa5b5779d43d4e78580b64&units=imperial&q=lyngseidet
    Processing Record 213 | pasighat
    http://api.openweathermap.org/data/2.5/weather?appid=a412e057dbaa5b5779d43d4e78580b64&units=imperial&q=pasighat
    Processing Record 214 | port augusta
    http://api.openweathermap.org/data/2.5/weather?appid=a412e057dbaa5b5779d43d4e78580b64&units=imperial&q=port%20augusta
    Processing Record 215 | toftir
    http://api.openweathermap.org/data/2.5/weather?appid=a412e057dbaa5b5779d43d4e78580b64&units=imperial&q=toftir
    No record for city:toftir
    Processing Record 216 | satitoa
    http://api.openweathermap.org/data/2.5/weather?appid=a412e057dbaa5b5779d43d4e78580b64&units=imperial&q=satitoa
    No record for city:satitoa
    Processing Record 217 | hambantota
    http://api.openweathermap.org/data/2.5/weather?appid=a412e057dbaa5b5779d43d4e78580b64&units=imperial&q=hambantota
    Processing Record 218 | ewa beach
    http://api.openweathermap.org/data/2.5/weather?appid=a412e057dbaa5b5779d43d4e78580b64&units=imperial&q=ewa%20beach
    Processing Record 219 | kaoma
    http://api.openweathermap.org/data/2.5/weather?appid=a412e057dbaa5b5779d43d4e78580b64&units=imperial&q=kaoma
    Processing Record 220 | bur gabo
    http://api.openweathermap.org/data/2.5/weather?appid=a412e057dbaa5b5779d43d4e78580b64&units=imperial&q=bur%20gabo
    No record for city:bur gabo
    Processing Record 221 | klaksvik
    http://api.openweathermap.org/data/2.5/weather?appid=a412e057dbaa5b5779d43d4e78580b64&units=imperial&q=klaksvik
    Processing Record 222 | kalmunai
    http://api.openweathermap.org/data/2.5/weather?appid=a412e057dbaa5b5779d43d4e78580b64&units=imperial&q=kalmunai
    Processing Record 223 | dunedin
    http://api.openweathermap.org/data/2.5/weather?appid=a412e057dbaa5b5779d43d4e78580b64&units=imperial&q=dunedin
    Processing Record 224 | mareeba
    http://api.openweathermap.org/data/2.5/weather?appid=a412e057dbaa5b5779d43d4e78580b64&units=imperial&q=mareeba
    Processing Record 225 | zhuhai
    http://api.openweathermap.org/data/2.5/weather?appid=a412e057dbaa5b5779d43d4e78580b64&units=imperial&q=zhuhai
    Processing Record 226 | gberia fotombu
    http://api.openweathermap.org/data/2.5/weather?appid=a412e057dbaa5b5779d43d4e78580b64&units=imperial&q=gberia%20fotombu
    Processing Record 227 | avarua
    http://api.openweathermap.org/data/2.5/weather?appid=a412e057dbaa5b5779d43d4e78580b64&units=imperial&q=avarua
    Processing Record 228 | birjand
    http://api.openweathermap.org/data/2.5/weather?appid=a412e057dbaa5b5779d43d4e78580b64&units=imperial&q=birjand
    Processing Record 229 | narsaq
    http://api.openweathermap.org/data/2.5/weather?appid=a412e057dbaa5b5779d43d4e78580b64&units=imperial&q=narsaq
    Processing Record 230 | cody
    http://api.openweathermap.org/data/2.5/weather?appid=a412e057dbaa5b5779d43d4e78580b64&units=imperial&q=cody
    Processing Record 231 | kailua
    http://api.openweathermap.org/data/2.5/weather?appid=a412e057dbaa5b5779d43d4e78580b64&units=imperial&q=kailua
    Processing Record 232 | mirnyy
    http://api.openweathermap.org/data/2.5/weather?appid=a412e057dbaa5b5779d43d4e78580b64&units=imperial&q=mirnyy
    Processing Record 233 | nouadhibou
    http://api.openweathermap.org/data/2.5/weather?appid=a412e057dbaa5b5779d43d4e78580b64&units=imperial&q=nouadhibou
    Processing Record 234 | ahipara
    http://api.openweathermap.org/data/2.5/weather?appid=a412e057dbaa5b5779d43d4e78580b64&units=imperial&q=ahipara
    Processing Record 235 | gudari
    http://api.openweathermap.org/data/2.5/weather?appid=a412e057dbaa5b5779d43d4e78580b64&units=imperial&q=gudari
    Processing Record 236 | crab hill
    http://api.openweathermap.org/data/2.5/weather?appid=a412e057dbaa5b5779d43d4e78580b64&units=imperial&q=crab%20hill
    No record for city:crab hill
    Processing Record 237 | bluff
    http://api.openweathermap.org/data/2.5/weather?appid=a412e057dbaa5b5779d43d4e78580b64&units=imperial&q=bluff
    Processing Record 238 | ouro preto do oeste
    http://api.openweathermap.org/data/2.5/weather?appid=a412e057dbaa5b5779d43d4e78580b64&units=imperial&q=ouro%20preto%20do%20oeste
    Processing Record 239 | mahebourg
    http://api.openweathermap.org/data/2.5/weather?appid=a412e057dbaa5b5779d43d4e78580b64&units=imperial&q=mahebourg
    Processing Record 240 | toamasina
    http://api.openweathermap.org/data/2.5/weather?appid=a412e057dbaa5b5779d43d4e78580b64&units=imperial&q=toamasina
    Processing Record 241 | geraldton
    http://api.openweathermap.org/data/2.5/weather?appid=a412e057dbaa5b5779d43d4e78580b64&units=imperial&q=geraldton
    Processing Record 242 | arlit
    http://api.openweathermap.org/data/2.5/weather?appid=a412e057dbaa5b5779d43d4e78580b64&units=imperial&q=arlit
    Processing Record 243 | bandar-e lengeh
    http://api.openweathermap.org/data/2.5/weather?appid=a412e057dbaa5b5779d43d4e78580b64&units=imperial&q=bandar-e%20lengeh
    Processing Record 244 | tucurui
    http://api.openweathermap.org/data/2.5/weather?appid=a412e057dbaa5b5779d43d4e78580b64&units=imperial&q=tucurui
    Processing Record 245 | canela
    http://api.openweathermap.org/data/2.5/weather?appid=a412e057dbaa5b5779d43d4e78580b64&units=imperial&q=canela
    Processing Record 246 | aklavik
    http://api.openweathermap.org/data/2.5/weather?appid=a412e057dbaa5b5779d43d4e78580b64&units=imperial&q=aklavik
    Processing Record 247 | taltal
    http://api.openweathermap.org/data/2.5/weather?appid=a412e057dbaa5b5779d43d4e78580b64&units=imperial&q=taltal
    Processing Record 248 | krasnoselkup
    http://api.openweathermap.org/data/2.5/weather?appid=a412e057dbaa5b5779d43d4e78580b64&units=imperial&q=krasnoselkup
    No record for city:krasnoselkup
    Processing Record 249 | havre
    http://api.openweathermap.org/data/2.5/weather?appid=a412e057dbaa5b5779d43d4e78580b64&units=imperial&q=havre
    Processing Record 250 | constitucion
    http://api.openweathermap.org/data/2.5/weather?appid=a412e057dbaa5b5779d43d4e78580b64&units=imperial&q=constitucion
    Processing Record 251 | tarija
    http://api.openweathermap.org/data/2.5/weather?appid=a412e057dbaa5b5779d43d4e78580b64&units=imperial&q=tarija
    Processing Record 252 | baykit
    http://api.openweathermap.org/data/2.5/weather?appid=a412e057dbaa5b5779d43d4e78580b64&units=imperial&q=baykit
    Processing Record 253 | znamenskoye
    http://api.openweathermap.org/data/2.5/weather?appid=a412e057dbaa5b5779d43d4e78580b64&units=imperial&q=znamenskoye
    Processing Record 254 | tazovskiy
    http://api.openweathermap.org/data/2.5/weather?appid=a412e057dbaa5b5779d43d4e78580b64&units=imperial&q=tazovskiy
    Processing Record 255 | alofi
    http://api.openweathermap.org/data/2.5/weather?appid=a412e057dbaa5b5779d43d4e78580b64&units=imperial&q=alofi
    Processing Record 256 | tezu
    http://api.openweathermap.org/data/2.5/weather?appid=a412e057dbaa5b5779d43d4e78580b64&units=imperial&q=tezu
    Processing Record 257 | barentsburg
    http://api.openweathermap.org/data/2.5/weather?appid=a412e057dbaa5b5779d43d4e78580b64&units=imperial&q=barentsburg
    No record for city:barentsburg
    Processing Record 258 | beringovskiy
    http://api.openweathermap.org/data/2.5/weather?appid=a412e057dbaa5b5779d43d4e78580b64&units=imperial&q=beringovskiy
    Processing Record 259 | guerrero negro
    http://api.openweathermap.org/data/2.5/weather?appid=a412e057dbaa5b5779d43d4e78580b64&units=imperial&q=guerrero%20negro
    Processing Record 260 | severo-kurilsk
    http://api.openweathermap.org/data/2.5/weather?appid=a412e057dbaa5b5779d43d4e78580b64&units=imperial&q=severo-kurilsk
    Processing Record 261 | ostrovnoy
    http://api.openweathermap.org/data/2.5/weather?appid=a412e057dbaa5b5779d43d4e78580b64&units=imperial&q=ostrovnoy
    Processing Record 262 | saint-louis
    http://api.openweathermap.org/data/2.5/weather?appid=a412e057dbaa5b5779d43d4e78580b64&units=imperial&q=saint-louis
    Processing Record 263 | hami
    http://api.openweathermap.org/data/2.5/weather?appid=a412e057dbaa5b5779d43d4e78580b64&units=imperial&q=hami
    Processing Record 264 | ranong
    http://api.openweathermap.org/data/2.5/weather?appid=a412e057dbaa5b5779d43d4e78580b64&units=imperial&q=ranong
    Processing Record 265 | kodiak
    http://api.openweathermap.org/data/2.5/weather?appid=a412e057dbaa5b5779d43d4e78580b64&units=imperial&q=kodiak
    Processing Record 266 | nizhneyansk
    http://api.openweathermap.org/data/2.5/weather?appid=a412e057dbaa5b5779d43d4e78580b64&units=imperial&q=nizhneyansk
    No record for city:nizhneyansk
    Processing Record 267 | tuktoyaktuk
    http://api.openweathermap.org/data/2.5/weather?appid=a412e057dbaa5b5779d43d4e78580b64&units=imperial&q=tuktoyaktuk
    Processing Record 268 | el alto
    http://api.openweathermap.org/data/2.5/weather?appid=a412e057dbaa5b5779d43d4e78580b64&units=imperial&q=el%20alto
    Processing Record 269 | port shepstone
    http://api.openweathermap.org/data/2.5/weather?appid=a412e057dbaa5b5779d43d4e78580b64&units=imperial&q=port%20shepstone
    Processing Record 270 | acarau
    http://api.openweathermap.org/data/2.5/weather?appid=a412e057dbaa5b5779d43d4e78580b64&units=imperial&q=acarau
    No record for city:acarau
    Processing Record 271 | chagda
    http://api.openweathermap.org/data/2.5/weather?appid=a412e057dbaa5b5779d43d4e78580b64&units=imperial&q=chagda
    No record for city:chagda
    Processing Record 272 | taoudenni
    http://api.openweathermap.org/data/2.5/weather?appid=a412e057dbaa5b5779d43d4e78580b64&units=imperial&q=taoudenni
    Processing Record 273 | bremerton
    http://api.openweathermap.org/data/2.5/weather?appid=a412e057dbaa5b5779d43d4e78580b64&units=imperial&q=bremerton
    Processing Record 274 | yar-sale
    http://api.openweathermap.org/data/2.5/weather?appid=a412e057dbaa5b5779d43d4e78580b64&units=imperial&q=yar-sale
    Processing Record 275 | rafraf
    http://api.openweathermap.org/data/2.5/weather?appid=a412e057dbaa5b5779d43d4e78580b64&units=imperial&q=rafraf
    Processing Record 276 | hervey bay
    http://api.openweathermap.org/data/2.5/weather?appid=a412e057dbaa5b5779d43d4e78580b64&units=imperial&q=hervey%20bay
    Processing Record 277 | richards bay
    http://api.openweathermap.org/data/2.5/weather?appid=a412e057dbaa5b5779d43d4e78580b64&units=imperial&q=richards%20bay
    Processing Record 278 | bamenda
    http://api.openweathermap.org/data/2.5/weather?appid=a412e057dbaa5b5779d43d4e78580b64&units=imperial&q=bamenda
    Processing Record 279 | lao cai
    http://api.openweathermap.org/data/2.5/weather?appid=a412e057dbaa5b5779d43d4e78580b64&units=imperial&q=lao%20cai
    Processing Record 280 | tiarei
    http://api.openweathermap.org/data/2.5/weather?appid=a412e057dbaa5b5779d43d4e78580b64&units=imperial&q=tiarei
    Processing Record 281 | keuruu
    http://api.openweathermap.org/data/2.5/weather?appid=a412e057dbaa5b5779d43d4e78580b64&units=imperial&q=keuruu
    Processing Record 282 | constantine
    http://api.openweathermap.org/data/2.5/weather?appid=a412e057dbaa5b5779d43d4e78580b64&units=imperial&q=constantine
    Processing Record 283 | chicama
    http://api.openweathermap.org/data/2.5/weather?appid=a412e057dbaa5b5779d43d4e78580b64&units=imperial&q=chicama
    Processing Record 284 | domoni
    http://api.openweathermap.org/data/2.5/weather?appid=a412e057dbaa5b5779d43d4e78580b64&units=imperial&q=domoni
    No record for city:domoni
    Processing Record 285 | port elizabeth
    http://api.openweathermap.org/data/2.5/weather?appid=a412e057dbaa5b5779d43d4e78580b64&units=imperial&q=port%20elizabeth
    Processing Record 286 | vite
    http://api.openweathermap.org/data/2.5/weather?appid=a412e057dbaa5b5779d43d4e78580b64&units=imperial&q=vite
    Processing Record 287 | grants pass
    http://api.openweathermap.org/data/2.5/weather?appid=a412e057dbaa5b5779d43d4e78580b64&units=imperial&q=grants%20pass
    Processing Record 288 | macia
    http://api.openweathermap.org/data/2.5/weather?appid=a412e057dbaa5b5779d43d4e78580b64&units=imperial&q=macia
    Processing Record 289 | zhanakorgan
    http://api.openweathermap.org/data/2.5/weather?appid=a412e057dbaa5b5779d43d4e78580b64&units=imperial&q=zhanakorgan
    Processing Record 290 | felidhoo
    http://api.openweathermap.org/data/2.5/weather?appid=a412e057dbaa5b5779d43d4e78580b64&units=imperial&q=felidhoo
    No record for city:felidhoo
    Processing Record 291 | husavik
    http://api.openweathermap.org/data/2.5/weather?appid=a412e057dbaa5b5779d43d4e78580b64&units=imperial&q=husavik
    Processing Record 292 | poum
    http://api.openweathermap.org/data/2.5/weather?appid=a412e057dbaa5b5779d43d4e78580b64&units=imperial&q=poum
    Processing Record 293 | barrow
    http://api.openweathermap.org/data/2.5/weather?appid=a412e057dbaa5b5779d43d4e78580b64&units=imperial&q=barrow
    Processing Record 294 | saint-augustin
    http://api.openweathermap.org/data/2.5/weather?appid=a412e057dbaa5b5779d43d4e78580b64&units=imperial&q=saint-augustin
    Processing Record 295 | roebourne
    http://api.openweathermap.org/data/2.5/weather?appid=a412e057dbaa5b5779d43d4e78580b64&units=imperial&q=roebourne
    Processing Record 296 | astoria
    http://api.openweathermap.org/data/2.5/weather?appid=a412e057dbaa5b5779d43d4e78580b64&units=imperial&q=astoria
    Processing Record 297 | apex
    http://api.openweathermap.org/data/2.5/weather?appid=a412e057dbaa5b5779d43d4e78580b64&units=imperial&q=apex
    Processing Record 298 | tirumullaivasal
    http://api.openweathermap.org/data/2.5/weather?appid=a412e057dbaa5b5779d43d4e78580b64&units=imperial&q=tirumullaivasal
    Processing Record 299 | vohibinany
    http://api.openweathermap.org/data/2.5/weather?appid=a412e057dbaa5b5779d43d4e78580b64&units=imperial&q=vohibinany
    Processing Record 300 | bushenyi
    http://api.openweathermap.org/data/2.5/weather?appid=a412e057dbaa5b5779d43d4e78580b64&units=imperial&q=bushenyi
    Processing Record 301 | parras
    http://api.openweathermap.org/data/2.5/weather?appid=a412e057dbaa5b5779d43d4e78580b64&units=imperial&q=parras
    No record for city:parras
    Processing Record 302 | hailey
    http://api.openweathermap.org/data/2.5/weather?appid=a412e057dbaa5b5779d43d4e78580b64&units=imperial&q=hailey
    Processing Record 303 | nizhneivkino
    http://api.openweathermap.org/data/2.5/weather?appid=a412e057dbaa5b5779d43d4e78580b64&units=imperial&q=nizhneivkino
    Processing Record 304 | punta arenas
    http://api.openweathermap.org/data/2.5/weather?appid=a412e057dbaa5b5779d43d4e78580b64&units=imperial&q=punta%20arenas
    Processing Record 305 | pisco
    http://api.openweathermap.org/data/2.5/weather?appid=a412e057dbaa5b5779d43d4e78580b64&units=imperial&q=pisco
    Processing Record 306 | verkhnyaya sinyachikha
    http://api.openweathermap.org/data/2.5/weather?appid=a412e057dbaa5b5779d43d4e78580b64&units=imperial&q=verkhnyaya%20sinyachikha
    Processing Record 307 | pepperell
    http://api.openweathermap.org/data/2.5/weather?appid=a412e057dbaa5b5779d43d4e78580b64&units=imperial&q=pepperell
    Processing Record 308 | haines junction
    http://api.openweathermap.org/data/2.5/weather?appid=a412e057dbaa5b5779d43d4e78580b64&units=imperial&q=haines%20junction
    Processing Record 309 | tasbuget
    http://api.openweathermap.org/data/2.5/weather?appid=a412e057dbaa5b5779d43d4e78580b64&units=imperial&q=tasbuget
    No record for city:tasbuget
    Processing Record 310 | nuuk
    http://api.openweathermap.org/data/2.5/weather?appid=a412e057dbaa5b5779d43d4e78580b64&units=imperial&q=nuuk
    Processing Record 311 | gurgaon
    http://api.openweathermap.org/data/2.5/weather?appid=a412e057dbaa5b5779d43d4e78580b64&units=imperial&q=gurgaon
    Processing Record 312 | deyang
    http://api.openweathermap.org/data/2.5/weather?appid=a412e057dbaa5b5779d43d4e78580b64&units=imperial&q=deyang
    Processing Record 313 | nantucket
    http://api.openweathermap.org/data/2.5/weather?appid=a412e057dbaa5b5779d43d4e78580b64&units=imperial&q=nantucket
    Processing Record 314 | saint-philippe
    http://api.openweathermap.org/data/2.5/weather?appid=a412e057dbaa5b5779d43d4e78580b64&units=imperial&q=saint-philippe
    Processing Record 315 | suluq
    http://api.openweathermap.org/data/2.5/weather?appid=a412e057dbaa5b5779d43d4e78580b64&units=imperial&q=suluq
    Processing Record 316 | cahabon
    http://api.openweathermap.org/data/2.5/weather?appid=a412e057dbaa5b5779d43d4e78580b64&units=imperial&q=cahabon
    Processing Record 317 | moron
    http://api.openweathermap.org/data/2.5/weather?appid=a412e057dbaa5b5779d43d4e78580b64&units=imperial&q=moron
    Processing Record 318 | nikki
    http://api.openweathermap.org/data/2.5/weather?appid=a412e057dbaa5b5779d43d4e78580b64&units=imperial&q=nikki
    Processing Record 319 | narasannapeta
    http://api.openweathermap.org/data/2.5/weather?appid=a412e057dbaa5b5779d43d4e78580b64&units=imperial&q=narasannapeta
    Processing Record 320 | chuy
    http://api.openweathermap.org/data/2.5/weather?appid=a412e057dbaa5b5779d43d4e78580b64&units=imperial&q=chuy
    Processing Record 321 | buraydah
    http://api.openweathermap.org/data/2.5/weather?appid=a412e057dbaa5b5779d43d4e78580b64&units=imperial&q=buraydah
    Processing Record 322 | saleaula
    http://api.openweathermap.org/data/2.5/weather?appid=a412e057dbaa5b5779d43d4e78580b64&units=imperial&q=saleaula
    No record for city:saleaula
    Processing Record 323 | fortuna
    http://api.openweathermap.org/data/2.5/weather?appid=a412e057dbaa5b5779d43d4e78580b64&units=imperial&q=fortuna
    Processing Record 324 | luderitz
    http://api.openweathermap.org/data/2.5/weather?appid=a412e057dbaa5b5779d43d4e78580b64&units=imperial&q=luderitz
    Processing Record 325 | cape town
    http://api.openweathermap.org/data/2.5/weather?appid=a412e057dbaa5b5779d43d4e78580b64&units=imperial&q=cape%20town
    Processing Record 326 | kuching
    http://api.openweathermap.org/data/2.5/weather?appid=a412e057dbaa5b5779d43d4e78580b64&units=imperial&q=kuching
    Processing Record 327 | canutama
    http://api.openweathermap.org/data/2.5/weather?appid=a412e057dbaa5b5779d43d4e78580b64&units=imperial&q=canutama
    Processing Record 328 | sarai alamgir
    http://api.openweathermap.org/data/2.5/weather?appid=a412e057dbaa5b5779d43d4e78580b64&units=imperial&q=sarai%20alamgir
    Processing Record 329 | walvis bay
    http://api.openweathermap.org/data/2.5/weather?appid=a412e057dbaa5b5779d43d4e78580b64&units=imperial&q=walvis%20bay
    Processing Record 330 | busselton
    http://api.openweathermap.org/data/2.5/weather?appid=a412e057dbaa5b5779d43d4e78580b64&units=imperial&q=busselton
    Processing Record 331 | batagay
    http://api.openweathermap.org/data/2.5/weather?appid=a412e057dbaa5b5779d43d4e78580b64&units=imperial&q=batagay
    Processing Record 332 | batemans bay
    http://api.openweathermap.org/data/2.5/weather?appid=a412e057dbaa5b5779d43d4e78580b64&units=imperial&q=batemans%20bay
    Processing Record 333 | louisbourg
    http://api.openweathermap.org/data/2.5/weather?appid=a412e057dbaa5b5779d43d4e78580b64&units=imperial&q=louisbourg
    No record for city:louisbourg
    Processing Record 334 | grand river south east
    http://api.openweathermap.org/data/2.5/weather?appid=a412e057dbaa5b5779d43d4e78580b64&units=imperial&q=grand%20river%20south%20east
    No record for city:grand river south east
    Processing Record 335 | omboue
    http://api.openweathermap.org/data/2.5/weather?appid=a412e057dbaa5b5779d43d4e78580b64&units=imperial&q=omboue
    Processing Record 336 | ust-nera
    http://api.openweathermap.org/data/2.5/weather?appid=a412e057dbaa5b5779d43d4e78580b64&units=imperial&q=ust-nera
    Processing Record 337 | oga
    http://api.openweathermap.org/data/2.5/weather?appid=a412e057dbaa5b5779d43d4e78580b64&units=imperial&q=oga
    Processing Record 338 | olinda
    http://api.openweathermap.org/data/2.5/weather?appid=a412e057dbaa5b5779d43d4e78580b64&units=imperial&q=olinda
    Processing Record 339 | coffs harbour
    http://api.openweathermap.org/data/2.5/weather?appid=a412e057dbaa5b5779d43d4e78580b64&units=imperial&q=coffs%20harbour
    Processing Record 340 | okhotsk
    http://api.openweathermap.org/data/2.5/weather?appid=a412e057dbaa5b5779d43d4e78580b64&units=imperial&q=okhotsk
    Processing Record 341 | alghero
    http://api.openweathermap.org/data/2.5/weather?appid=a412e057dbaa5b5779d43d4e78580b64&units=imperial&q=alghero
    Processing Record 342 | kathmandu
    http://api.openweathermap.org/data/2.5/weather?appid=a412e057dbaa5b5779d43d4e78580b64&units=imperial&q=kathmandu
    Processing Record 343 | brookhaven
    http://api.openweathermap.org/data/2.5/weather?appid=a412e057dbaa5b5779d43d4e78580b64&units=imperial&q=brookhaven
    Processing Record 344 | marrakesh
    http://api.openweathermap.org/data/2.5/weather?appid=a412e057dbaa5b5779d43d4e78580b64&units=imperial&q=marrakesh
    Processing Record 345 | kijang
    http://api.openweathermap.org/data/2.5/weather?appid=a412e057dbaa5b5779d43d4e78580b64&units=imperial&q=kijang
    Processing Record 346 | yugorsk
    http://api.openweathermap.org/data/2.5/weather?appid=a412e057dbaa5b5779d43d4e78580b64&units=imperial&q=yugorsk
    Processing Record 347 | bagdarin
    http://api.openweathermap.org/data/2.5/weather?appid=a412e057dbaa5b5779d43d4e78580b64&units=imperial&q=bagdarin
    Processing Record 348 | baghdad
    http://api.openweathermap.org/data/2.5/weather?appid=a412e057dbaa5b5779d43d4e78580b64&units=imperial&q=baghdad
    Processing Record 349 | hun
    http://api.openweathermap.org/data/2.5/weather?appid=a412e057dbaa5b5779d43d4e78580b64&units=imperial&q=hun
    Processing Record 350 | pedra branca
    http://api.openweathermap.org/data/2.5/weather?appid=a412e057dbaa5b5779d43d4e78580b64&units=imperial&q=pedra%20branca
    Processing Record 351 | vestmannaeyjar
    http://api.openweathermap.org/data/2.5/weather?appid=a412e057dbaa5b5779d43d4e78580b64&units=imperial&q=vestmannaeyjar
    Processing Record 352 | saint-francois
    http://api.openweathermap.org/data/2.5/weather?appid=a412e057dbaa5b5779d43d4e78580b64&units=imperial&q=saint-francois
    Processing Record 353 | sandnessjoen
    http://api.openweathermap.org/data/2.5/weather?appid=a412e057dbaa5b5779d43d4e78580b64&units=imperial&q=sandnessjoen
    Processing Record 354 | chimbote
    http://api.openweathermap.org/data/2.5/weather?appid=a412e057dbaa5b5779d43d4e78580b64&units=imperial&q=chimbote
    Processing Record 355 | pitimbu
    http://api.openweathermap.org/data/2.5/weather?appid=a412e057dbaa5b5779d43d4e78580b64&units=imperial&q=pitimbu
    Processing Record 356 | savannah bight
    http://api.openweathermap.org/data/2.5/weather?appid=a412e057dbaa5b5779d43d4e78580b64&units=imperial&q=savannah%20bight
    Processing Record 357 | guanambi
    http://api.openweathermap.org/data/2.5/weather?appid=a412e057dbaa5b5779d43d4e78580b64&units=imperial&q=guanambi
    Processing Record 358 | rawson
    http://api.openweathermap.org/data/2.5/weather?appid=a412e057dbaa5b5779d43d4e78580b64&units=imperial&q=rawson
    Processing Record 359 | puerto ayora
    http://api.openweathermap.org/data/2.5/weather?appid=a412e057dbaa5b5779d43d4e78580b64&units=imperial&q=puerto%20ayora
    Processing Record 360 | kununurra
    http://api.openweathermap.org/data/2.5/weather?appid=a412e057dbaa5b5779d43d4e78580b64&units=imperial&q=kununurra
    Processing Record 361 | acheng
    http://api.openweathermap.org/data/2.5/weather?appid=a412e057dbaa5b5779d43d4e78580b64&units=imperial&q=acheng
    Processing Record 362 | natal
    http://api.openweathermap.org/data/2.5/weather?appid=a412e057dbaa5b5779d43d4e78580b64&units=imperial&q=natal
    Processing Record 363 | tambopata
    http://api.openweathermap.org/data/2.5/weather?appid=a412e057dbaa5b5779d43d4e78580b64&units=imperial&q=tambopata
    No record for city:tambopata
    Processing Record 364 | alice town
    http://api.openweathermap.org/data/2.5/weather?appid=a412e057dbaa5b5779d43d4e78580b64&units=imperial&q=alice%20town
    Processing Record 365 | saldanha
    http://api.openweathermap.org/data/2.5/weather?appid=a412e057dbaa5b5779d43d4e78580b64&units=imperial&q=saldanha
    Processing Record 366 | nabire
    http://api.openweathermap.org/data/2.5/weather?appid=a412e057dbaa5b5779d43d4e78580b64&units=imperial&q=nabire
    Processing Record 367 | isangel
    http://api.openweathermap.org/data/2.5/weather?appid=a412e057dbaa5b5779d43d4e78580b64&units=imperial&q=isangel
    Processing Record 368 | taolanaro
    http://api.openweathermap.org/data/2.5/weather?appid=a412e057dbaa5b5779d43d4e78580b64&units=imperial&q=taolanaro
    No record for city:taolanaro
    Processing Record 369 | tabas
    http://api.openweathermap.org/data/2.5/weather?appid=a412e057dbaa5b5779d43d4e78580b64&units=imperial&q=tabas
    Processing Record 370 | cabo san lucas
    http://api.openweathermap.org/data/2.5/weather?appid=a412e057dbaa5b5779d43d4e78580b64&units=imperial&q=cabo%20san%20lucas
    Processing Record 371 | porto novo
    http://api.openweathermap.org/data/2.5/weather?appid=a412e057dbaa5b5779d43d4e78580b64&units=imperial&q=porto%20novo
    Processing Record 372 | victor harbor
    http://api.openweathermap.org/data/2.5/weather?appid=a412e057dbaa5b5779d43d4e78580b64&units=imperial&q=victor%20harbor
    Processing Record 373 | tuggurt
    http://api.openweathermap.org/data/2.5/weather?appid=a412e057dbaa5b5779d43d4e78580b64&units=imperial&q=tuggurt
    No record for city:tuggurt
    Processing Record 374 | arroyo
    http://api.openweathermap.org/data/2.5/weather?appid=a412e057dbaa5b5779d43d4e78580b64&units=imperial&q=arroyo
    Processing Record 375 | santa isabel do rio negro
    http://api.openweathermap.org/data/2.5/weather?appid=a412e057dbaa5b5779d43d4e78580b64&units=imperial&q=santa%20isabel%20do%20rio%20negro
    Processing Record 376 | male
    http://api.openweathermap.org/data/2.5/weather?appid=a412e057dbaa5b5779d43d4e78580b64&units=imperial&q=male
    Processing Record 377 | caborca
    http://api.openweathermap.org/data/2.5/weather?appid=a412e057dbaa5b5779d43d4e78580b64&units=imperial&q=caborca
    Processing Record 378 | dudinka
    http://api.openweathermap.org/data/2.5/weather?appid=a412e057dbaa5b5779d43d4e78580b64&units=imperial&q=dudinka
    Processing Record 379 | odder
    http://api.openweathermap.org/data/2.5/weather?appid=a412e057dbaa5b5779d43d4e78580b64&units=imperial&q=odder
    Processing Record 380 | payakumbuh
    http://api.openweathermap.org/data/2.5/weather?appid=a412e057dbaa5b5779d43d4e78580b64&units=imperial&q=payakumbuh
    Processing Record 381 | karratha
    http://api.openweathermap.org/data/2.5/weather?appid=a412e057dbaa5b5779d43d4e78580b64&units=imperial&q=karratha
    Processing Record 382 | lagoa
    http://api.openweathermap.org/data/2.5/weather?appid=a412e057dbaa5b5779d43d4e78580b64&units=imperial&q=lagoa
    Processing Record 383 | clyde river
    http://api.openweathermap.org/data/2.5/weather?appid=a412e057dbaa5b5779d43d4e78580b64&units=imperial&q=clyde%20river
    Processing Record 384 | del rio
    http://api.openweathermap.org/data/2.5/weather?appid=a412e057dbaa5b5779d43d4e78580b64&units=imperial&q=del%20rio
    Processing Record 385 | emerald
    http://api.openweathermap.org/data/2.5/weather?appid=a412e057dbaa5b5779d43d4e78580b64&units=imperial&q=emerald
    Processing Record 386 | tamasane
    http://api.openweathermap.org/data/2.5/weather?appid=a412e057dbaa5b5779d43d4e78580b64&units=imperial&q=tamasane
    Processing Record 387 | bambous virieux
    http://api.openweathermap.org/data/2.5/weather?appid=a412e057dbaa5b5779d43d4e78580b64&units=imperial&q=bambous%20virieux
    Processing Record 388 | iturama
    http://api.openweathermap.org/data/2.5/weather?appid=a412e057dbaa5b5779d43d4e78580b64&units=imperial&q=iturama
    Processing Record 389 | shache
    http://api.openweathermap.org/data/2.5/weather?appid=a412e057dbaa5b5779d43d4e78580b64&units=imperial&q=shache
    Processing Record 390 | kubachi
    http://api.openweathermap.org/data/2.5/weather?appid=a412e057dbaa5b5779d43d4e78580b64&units=imperial&q=kubachi
    Processing Record 391 | saint george
    http://api.openweathermap.org/data/2.5/weather?appid=a412e057dbaa5b5779d43d4e78580b64&units=imperial&q=saint%20george
    Processing Record 392 | luganville
    http://api.openweathermap.org/data/2.5/weather?appid=a412e057dbaa5b5779d43d4e78580b64&units=imperial&q=luganville
    Processing Record 393 | sabha
    http://api.openweathermap.org/data/2.5/weather?appid=a412e057dbaa5b5779d43d4e78580b64&units=imperial&q=sabha
    Processing Record 394 | sisophon
    http://api.openweathermap.org/data/2.5/weather?appid=a412e057dbaa5b5779d43d4e78580b64&units=imperial&q=sisophon
    Processing Record 395 | kahului
    http://api.openweathermap.org/data/2.5/weather?appid=a412e057dbaa5b5779d43d4e78580b64&units=imperial&q=kahului
    Processing Record 396 | brazzaville
    http://api.openweathermap.org/data/2.5/weather?appid=a412e057dbaa5b5779d43d4e78580b64&units=imperial&q=brazzaville
    Processing Record 397 | port blair
    http://api.openweathermap.org/data/2.5/weather?appid=a412e057dbaa5b5779d43d4e78580b64&units=imperial&q=port%20blair
    Processing Record 398 | dikson
    http://api.openweathermap.org/data/2.5/weather?appid=a412e057dbaa5b5779d43d4e78580b64&units=imperial&q=dikson
    Processing Record 399 | bathsheba
    http://api.openweathermap.org/data/2.5/weather?appid=a412e057dbaa5b5779d43d4e78580b64&units=imperial&q=bathsheba
    Processing Record 400 | claresholm
    http://api.openweathermap.org/data/2.5/weather?appid=a412e057dbaa5b5779d43d4e78580b64&units=imperial&q=claresholm
    Processing Record 401 | beaufort
    http://api.openweathermap.org/data/2.5/weather?appid=a412e057dbaa5b5779d43d4e78580b64&units=imperial&q=beaufort
    Processing Record 402 | faanui
    http://api.openweathermap.org/data/2.5/weather?appid=a412e057dbaa5b5779d43d4e78580b64&units=imperial&q=faanui
    Processing Record 403 | watsa
    http://api.openweathermap.org/data/2.5/weather?appid=a412e057dbaa5b5779d43d4e78580b64&units=imperial&q=watsa
    Processing Record 404 | atrauli
    http://api.openweathermap.org/data/2.5/weather?appid=a412e057dbaa5b5779d43d4e78580b64&units=imperial&q=atrauli
    Processing Record 405 | nador
    http://api.openweathermap.org/data/2.5/weather?appid=a412e057dbaa5b5779d43d4e78580b64&units=imperial&q=nador
    Processing Record 406 | ekhabi
    http://api.openweathermap.org/data/2.5/weather?appid=a412e057dbaa5b5779d43d4e78580b64&units=imperial&q=ekhabi
    Processing Record 407 | san quintin
    http://api.openweathermap.org/data/2.5/weather?appid=a412e057dbaa5b5779d43d4e78580b64&units=imperial&q=san%20quintin
    Processing Record 408 | ucluelet
    http://api.openweathermap.org/data/2.5/weather?appid=a412e057dbaa5b5779d43d4e78580b64&units=imperial&q=ucluelet
    Processing Record 409 | a
    http://api.openweathermap.org/data/2.5/weather?appid=a412e057dbaa5b5779d43d4e78580b64&units=imperial&q=a
    No record for city:a
    Processing Record 410 | mujiayingzi
    http://api.openweathermap.org/data/2.5/weather?appid=a412e057dbaa5b5779d43d4e78580b64&units=imperial&q=mujiayingzi
    Processing Record 411 | barra do garcas
    http://api.openweathermap.org/data/2.5/weather?appid=a412e057dbaa5b5779d43d4e78580b64&units=imperial&q=barra%20do%20garcas
    Processing Record 412 | vila
    http://api.openweathermap.org/data/2.5/weather?appid=a412e057dbaa5b5779d43d4e78580b64&units=imperial&q=vila
    Processing Record 413 | san andres
    http://api.openweathermap.org/data/2.5/weather?appid=a412e057dbaa5b5779d43d4e78580b64&units=imperial&q=san%20andres
    Processing Record 414 | bereda
    http://api.openweathermap.org/data/2.5/weather?appid=a412e057dbaa5b5779d43d4e78580b64&units=imperial&q=bereda
    Processing Record 415 | vostok
    http://api.openweathermap.org/data/2.5/weather?appid=a412e057dbaa5b5779d43d4e78580b64&units=imperial&q=vostok
    Processing Record 416 | charagua
    http://api.openweathermap.org/data/2.5/weather?appid=a412e057dbaa5b5779d43d4e78580b64&units=imperial&q=charagua
    Processing Record 417 | kloulklubed
    http://api.openweathermap.org/data/2.5/weather?appid=a412e057dbaa5b5779d43d4e78580b64&units=imperial&q=kloulklubed
    Processing Record 418 | zhezkazgan
    http://api.openweathermap.org/data/2.5/weather?appid=a412e057dbaa5b5779d43d4e78580b64&units=imperial&q=zhezkazgan
    Processing Record 419 | orchard homes
    http://api.openweathermap.org/data/2.5/weather?appid=a412e057dbaa5b5779d43d4e78580b64&units=imperial&q=orchard%20homes
    Processing Record 420 | tumannyy
    http://api.openweathermap.org/data/2.5/weather?appid=a412e057dbaa5b5779d43d4e78580b64&units=imperial&q=tumannyy
    No record for city:tumannyy
    Processing Record 421 | samusu
    http://api.openweathermap.org/data/2.5/weather?appid=a412e057dbaa5b5779d43d4e78580b64&units=imperial&q=samusu
    No record for city:samusu
    Processing Record 422 | envira
    http://api.openweathermap.org/data/2.5/weather?appid=a412e057dbaa5b5779d43d4e78580b64&units=imperial&q=envira
    No record for city:envira
    Processing Record 423 | karatau
    http://api.openweathermap.org/data/2.5/weather?appid=a412e057dbaa5b5779d43d4e78580b64&units=imperial&q=karatau
    Processing Record 424 | umm durman
    http://api.openweathermap.org/data/2.5/weather?appid=a412e057dbaa5b5779d43d4e78580b64&units=imperial&q=umm%20durman
    No record for city:umm durman
    Processing Record 425 | manama
    http://api.openweathermap.org/data/2.5/weather?appid=a412e057dbaa5b5779d43d4e78580b64&units=imperial&q=manama
    Processing Record 426 | pentecoste
    http://api.openweathermap.org/data/2.5/weather?appid=a412e057dbaa5b5779d43d4e78580b64&units=imperial&q=pentecoste
    Processing Record 427 | bilma
    http://api.openweathermap.org/data/2.5/weather?appid=a412e057dbaa5b5779d43d4e78580b64&units=imperial&q=bilma
    Processing Record 428 | meulaboh
    http://api.openweathermap.org/data/2.5/weather?appid=a412e057dbaa5b5779d43d4e78580b64&units=imperial&q=meulaboh
    Processing Record 429 | grand centre
    http://api.openweathermap.org/data/2.5/weather?appid=a412e057dbaa5b5779d43d4e78580b64&units=imperial&q=grand%20centre
    No record for city:grand centre
    Processing Record 430 | copiapo
    http://api.openweathermap.org/data/2.5/weather?appid=a412e057dbaa5b5779d43d4e78580b64&units=imperial&q=copiapo
    Processing Record 431 | neiafu
    http://api.openweathermap.org/data/2.5/weather?appid=a412e057dbaa5b5779d43d4e78580b64&units=imperial&q=neiafu
    Processing Record 432 | stulovo
    http://api.openweathermap.org/data/2.5/weather?appid=a412e057dbaa5b5779d43d4e78580b64&units=imperial&q=stulovo
    Processing Record 433 | uwayl
    http://api.openweathermap.org/data/2.5/weather?appid=a412e057dbaa5b5779d43d4e78580b64&units=imperial&q=uwayl
    No record for city:uwayl
    Processing Record 434 | parola
    http://api.openweathermap.org/data/2.5/weather?appid=a412e057dbaa5b5779d43d4e78580b64&units=imperial&q=parola
    Processing Record 435 | san patricio
    http://api.openweathermap.org/data/2.5/weather?appid=a412e057dbaa5b5779d43d4e78580b64&units=imperial&q=san%20patricio
    Processing Record 436 | geri
    http://api.openweathermap.org/data/2.5/weather?appid=a412e057dbaa5b5779d43d4e78580b64&units=imperial&q=geri
    Processing Record 437 | olot
    http://api.openweathermap.org/data/2.5/weather?appid=a412e057dbaa5b5779d43d4e78580b64&units=imperial&q=olot
    Processing Record 438 | tutoia
    http://api.openweathermap.org/data/2.5/weather?appid=a412e057dbaa5b5779d43d4e78580b64&units=imperial&q=tutoia
    Processing Record 439 | neuquen
    http://api.openweathermap.org/data/2.5/weather?appid=a412e057dbaa5b5779d43d4e78580b64&units=imperial&q=neuquen
    Processing Record 440 | port hardy
    http://api.openweathermap.org/data/2.5/weather?appid=a412e057dbaa5b5779d43d4e78580b64&units=imperial&q=port%20hardy
    Processing Record 441 | angostura
    http://api.openweathermap.org/data/2.5/weather?appid=a412e057dbaa5b5779d43d4e78580b64&units=imperial&q=angostura
    Processing Record 442 | ribeira grande
    http://api.openweathermap.org/data/2.5/weather?appid=a412e057dbaa5b5779d43d4e78580b64&units=imperial&q=ribeira%20grande
    Processing Record 443 | port alfred
    http://api.openweathermap.org/data/2.5/weather?appid=a412e057dbaa5b5779d43d4e78580b64&units=imperial&q=port%20alfred
    Processing Record 444 | bilibino
    http://api.openweathermap.org/data/2.5/weather?appid=a412e057dbaa5b5779d43d4e78580b64&units=imperial&q=bilibino
    Processing Record 445 | marcona
    http://api.openweathermap.org/data/2.5/weather?appid=a412e057dbaa5b5779d43d4e78580b64&units=imperial&q=marcona
    No record for city:marcona
    Processing Record 446 | gondanglegi
    http://api.openweathermap.org/data/2.5/weather?appid=a412e057dbaa5b5779d43d4e78580b64&units=imperial&q=gondanglegi
    Processing Record 447 | esperance
    http://api.openweathermap.org/data/2.5/weather?appid=a412e057dbaa5b5779d43d4e78580b64&units=imperial&q=esperance
    Processing Record 448 | itarema
    http://api.openweathermap.org/data/2.5/weather?appid=a412e057dbaa5b5779d43d4e78580b64&units=imperial&q=itarema
    Processing Record 449 | santa rosa
    http://api.openweathermap.org/data/2.5/weather?appid=a412e057dbaa5b5779d43d4e78580b64&units=imperial&q=santa%20rosa
    Processing Record 450 | victoria point
    http://api.openweathermap.org/data/2.5/weather?appid=a412e057dbaa5b5779d43d4e78580b64&units=imperial&q=victoria%20point
    Processing Record 451 | deputatskiy
    http://api.openweathermap.org/data/2.5/weather?appid=a412e057dbaa5b5779d43d4e78580b64&units=imperial&q=deputatskiy
    Processing Record 452 | izumo
    http://api.openweathermap.org/data/2.5/weather?appid=a412e057dbaa5b5779d43d4e78580b64&units=imperial&q=izumo
    Processing Record 453 | nikolskoye
    http://api.openweathermap.org/data/2.5/weather?appid=a412e057dbaa5b5779d43d4e78580b64&units=imperial&q=nikolskoye
    Processing Record 454 | boende
    http://api.openweathermap.org/data/2.5/weather?appid=a412e057dbaa5b5779d43d4e78580b64&units=imperial&q=boende
    Processing Record 455 | quelimane
    http://api.openweathermap.org/data/2.5/weather?appid=a412e057dbaa5b5779d43d4e78580b64&units=imperial&q=quelimane
    Processing Record 456 | hithadhoo
    http://api.openweathermap.org/data/2.5/weather?appid=a412e057dbaa5b5779d43d4e78580b64&units=imperial&q=hithadhoo
    Processing Record 457 | raudeberg
    http://api.openweathermap.org/data/2.5/weather?appid=a412e057dbaa5b5779d43d4e78580b64&units=imperial&q=raudeberg
    Processing Record 458 | angoche
    http://api.openweathermap.org/data/2.5/weather?appid=a412e057dbaa5b5779d43d4e78580b64&units=imperial&q=angoche
    Processing Record 459 | rikitea
    http://api.openweathermap.org/data/2.5/weather?appid=a412e057dbaa5b5779d43d4e78580b64&units=imperial&q=rikitea
    Processing Record 460 | san jeronimo
    http://api.openweathermap.org/data/2.5/weather?appid=a412e057dbaa5b5779d43d4e78580b64&units=imperial&q=san%20jeronimo
    Processing Record 461 | prince rupert
    http://api.openweathermap.org/data/2.5/weather?appid=a412e057dbaa5b5779d43d4e78580b64&units=imperial&q=prince%20rupert
    Processing Record 462 | swedru
    http://api.openweathermap.org/data/2.5/weather?appid=a412e057dbaa5b5779d43d4e78580b64&units=imperial&q=swedru
    Processing Record 463 | sobolevo
    http://api.openweathermap.org/data/2.5/weather?appid=a412e057dbaa5b5779d43d4e78580b64&units=imperial&q=sobolevo
    Processing Record 464 | yanchukan
    http://api.openweathermap.org/data/2.5/weather?appid=a412e057dbaa5b5779d43d4e78580b64&units=imperial&q=yanchukan
    No record for city:yanchukan
    Processing Record 465 | henties bay
    http://api.openweathermap.org/data/2.5/weather?appid=a412e057dbaa5b5779d43d4e78580b64&units=imperial&q=henties%20bay
    Processing Record 466 | teodoro sampaio
    http://api.openweathermap.org/data/2.5/weather?appid=a412e057dbaa5b5779d43d4e78580b64&units=imperial&q=teodoro%20sampaio
    Processing Record 467 | general roca
    http://api.openweathermap.org/data/2.5/weather?appid=a412e057dbaa5b5779d43d4e78580b64&units=imperial&q=general%20roca
    Processing Record 468 | poya
    http://api.openweathermap.org/data/2.5/weather?appid=a412e057dbaa5b5779d43d4e78580b64&units=imperial&q=poya
    Processing Record 469 | mar del plata
    http://api.openweathermap.org/data/2.5/weather?appid=a412e057dbaa5b5779d43d4e78580b64&units=imperial&q=mar%20del%20plata
    Processing Record 470 | benghazi
    http://api.openweathermap.org/data/2.5/weather?appid=a412e057dbaa5b5779d43d4e78580b64&units=imperial&q=benghazi
    Processing Record 471 | tarudant
    http://api.openweathermap.org/data/2.5/weather?appid=a412e057dbaa5b5779d43d4e78580b64&units=imperial&q=tarudant
    No record for city:tarudant
    Processing Record 472 | yialos
    http://api.openweathermap.org/data/2.5/weather?appid=a412e057dbaa5b5779d43d4e78580b64&units=imperial&q=yialos
    No record for city:yialos
    Processing Record 473 | horodkivka
    http://api.openweathermap.org/data/2.5/weather?appid=a412e057dbaa5b5779d43d4e78580b64&units=imperial&q=horodkivka
    Processing Record 474 | apple valley
    http://api.openweathermap.org/data/2.5/weather?appid=a412e057dbaa5b5779d43d4e78580b64&units=imperial&q=apple%20valley
    Processing Record 475 | bentiu
    http://api.openweathermap.org/data/2.5/weather?appid=a412e057dbaa5b5779d43d4e78580b64&units=imperial&q=bentiu
    No record for city:bentiu
    Processing Record 476 | ustka
    http://api.openweathermap.org/data/2.5/weather?appid=a412e057dbaa5b5779d43d4e78580b64&units=imperial&q=ustka
    Processing Record 477 | duz
    http://api.openweathermap.org/data/2.5/weather?appid=a412e057dbaa5b5779d43d4e78580b64&units=imperial&q=duz
    No record for city:duz
    Processing Record 478 | daru
    http://api.openweathermap.org/data/2.5/weather?appid=a412e057dbaa5b5779d43d4e78580b64&units=imperial&q=daru
    Processing Record 479 | tiksi
    http://api.openweathermap.org/data/2.5/weather?appid=a412e057dbaa5b5779d43d4e78580b64&units=imperial&q=tiksi
    Processing Record 480 | sur
    http://api.openweathermap.org/data/2.5/weather?appid=a412e057dbaa5b5779d43d4e78580b64&units=imperial&q=sur
    Processing Record 481 | banda aceh
    http://api.openweathermap.org/data/2.5/weather?appid=a412e057dbaa5b5779d43d4e78580b64&units=imperial&q=banda%20aceh
    Processing Record 482 | hailar
    http://api.openweathermap.org/data/2.5/weather?appid=a412e057dbaa5b5779d43d4e78580b64&units=imperial&q=hailar
    Processing Record 483 | aviles
    http://api.openweathermap.org/data/2.5/weather?appid=a412e057dbaa5b5779d43d4e78580b64&units=imperial&q=aviles
    Processing Record 484 | litovko
    http://api.openweathermap.org/data/2.5/weather?appid=a412e057dbaa5b5779d43d4e78580b64&units=imperial&q=litovko
    Processing Record 485 | sorland
    http://api.openweathermap.org/data/2.5/weather?appid=a412e057dbaa5b5779d43d4e78580b64&units=imperial&q=sorland
    Processing Record 486 | tsihombe
    http://api.openweathermap.org/data/2.5/weather?appid=a412e057dbaa5b5779d43d4e78580b64&units=imperial&q=tsihombe
    No record for city:tsihombe
    Processing Record 487 | cayenne
    http://api.openweathermap.org/data/2.5/weather?appid=a412e057dbaa5b5779d43d4e78580b64&units=imperial&q=cayenne
    Processing Record 488 | sao filipe
    http://api.openweathermap.org/data/2.5/weather?appid=a412e057dbaa5b5779d43d4e78580b64&units=imperial&q=sao%20filipe
    Processing Record 489 | kirkland lake
    http://api.openweathermap.org/data/2.5/weather?appid=a412e057dbaa5b5779d43d4e78580b64&units=imperial&q=kirkland%20lake
    Processing Record 490 | dubbo
    http://api.openweathermap.org/data/2.5/weather?appid=a412e057dbaa5b5779d43d4e78580b64&units=imperial&q=dubbo
    Processing Record 491 | kapaa
    http://api.openweathermap.org/data/2.5/weather?appid=a412e057dbaa5b5779d43d4e78580b64&units=imperial&q=kapaa
    Processing Record 492 | gerede
    http://api.openweathermap.org/data/2.5/weather?appid=a412e057dbaa5b5779d43d4e78580b64&units=imperial&q=gerede
    Processing Record 493 | bengkulu
    http://api.openweathermap.org/data/2.5/weather?appid=a412e057dbaa5b5779d43d4e78580b64&units=imperial&q=bengkulu
    No record for city:bengkulu
    Processing Record 494 | cavalcante
    http://api.openweathermap.org/data/2.5/weather?appid=a412e057dbaa5b5779d43d4e78580b64&units=imperial&q=cavalcante
    Processing Record 495 | malkara
    http://api.openweathermap.org/data/2.5/weather?appid=a412e057dbaa5b5779d43d4e78580b64&units=imperial&q=malkara
    Processing Record 496 | carnarvon
    http://api.openweathermap.org/data/2.5/weather?appid=a412e057dbaa5b5779d43d4e78580b64&units=imperial&q=carnarvon
    Processing Record 497 | illoqqortoormiut
    http://api.openweathermap.org/data/2.5/weather?appid=a412e057dbaa5b5779d43d4e78580b64&units=imperial&q=illoqqortoormiut
    No record for city:illoqqortoormiut
    Processing Record 498 | shizunai
    http://api.openweathermap.org/data/2.5/weather?appid=a412e057dbaa5b5779d43d4e78580b64&units=imperial&q=shizunai
    Processing Record 499 | hearst
    http://api.openweathermap.org/data/2.5/weather?appid=a412e057dbaa5b5779d43d4e78580b64&units=imperial&q=hearst
    Processing Record 500 | kulhudhuffushi
    http://api.openweathermap.org/data/2.5/weather?appid=a412e057dbaa5b5779d43d4e78580b64&units=imperial&q=kulhudhuffushi
    Processing Record 501 | verkhnyaya pyshma
    http://api.openweathermap.org/data/2.5/weather?appid=a412e057dbaa5b5779d43d4e78580b64&units=imperial&q=verkhnyaya%20pyshma
    Processing Record 502 | ponta do sol
    http://api.openweathermap.org/data/2.5/weather?appid=a412e057dbaa5b5779d43d4e78580b64&units=imperial&q=ponta%20do%20sol
    Processing Record 503 | skibbereen
    http://api.openweathermap.org/data/2.5/weather?appid=a412e057dbaa5b5779d43d4e78580b64&units=imperial&q=skibbereen
    Processing Record 504 | bangkalan
    http://api.openweathermap.org/data/2.5/weather?appid=a412e057dbaa5b5779d43d4e78580b64&units=imperial&q=bangkalan
    Processing Record 505 | havoysund
    http://api.openweathermap.org/data/2.5/weather?appid=a412e057dbaa5b5779d43d4e78580b64&units=imperial&q=havoysund
    Processing Record 506 | villa carlos paz
    http://api.openweathermap.org/data/2.5/weather?appid=a412e057dbaa5b5779d43d4e78580b64&units=imperial&q=villa%20carlos%20paz
    Processing Record 507 | artyk
    http://api.openweathermap.org/data/2.5/weather?appid=a412e057dbaa5b5779d43d4e78580b64&units=imperial&q=artyk
    No record for city:artyk
    Processing Record 508 | kenai
    http://api.openweathermap.org/data/2.5/weather?appid=a412e057dbaa5b5779d43d4e78580b64&units=imperial&q=kenai
    Processing Record 509 | chum phae
    http://api.openweathermap.org/data/2.5/weather?appid=a412e057dbaa5b5779d43d4e78580b64&units=imperial&q=chum%20phae
    Processing Record 510 | peabiru
    http://api.openweathermap.org/data/2.5/weather?appid=a412e057dbaa5b5779d43d4e78580b64&units=imperial&q=peabiru
    Processing Record 511 | saint-joseph
    http://api.openweathermap.org/data/2.5/weather?appid=a412e057dbaa5b5779d43d4e78580b64&units=imperial&q=saint-joseph
    Processing Record 512 | belen
    http://api.openweathermap.org/data/2.5/weather?appid=a412e057dbaa5b5779d43d4e78580b64&units=imperial&q=belen
    Processing Record 513 | bud
    http://api.openweathermap.org/data/2.5/weather?appid=a412e057dbaa5b5779d43d4e78580b64&units=imperial&q=bud
    Processing Record 514 | thompson
    http://api.openweathermap.org/data/2.5/weather?appid=a412e057dbaa5b5779d43d4e78580b64&units=imperial&q=thompson
    Processing Record 515 | hilo
    http://api.openweathermap.org/data/2.5/weather?appid=a412e057dbaa5b5779d43d4e78580b64&units=imperial&q=hilo
    Processing Record 516 | awbari
    http://api.openweathermap.org/data/2.5/weather?appid=a412e057dbaa5b5779d43d4e78580b64&units=imperial&q=awbari
    Processing Record 517 | kampot
    http://api.openweathermap.org/data/2.5/weather?appid=a412e057dbaa5b5779d43d4e78580b64&units=imperial&q=kampot
    Processing Record 518 | datong
    http://api.openweathermap.org/data/2.5/weather?appid=a412e057dbaa5b5779d43d4e78580b64&units=imperial&q=datong
    Processing Record 519 | kirakira
    http://api.openweathermap.org/data/2.5/weather?appid=a412e057dbaa5b5779d43d4e78580b64&units=imperial&q=kirakira
    Processing Record 520 | panama city
    http://api.openweathermap.org/data/2.5/weather?appid=a412e057dbaa5b5779d43d4e78580b64&units=imperial&q=panama%20city
    Processing Record 521 | jega
    http://api.openweathermap.org/data/2.5/weather?appid=a412e057dbaa5b5779d43d4e78580b64&units=imperial&q=jega
    Processing Record 522 | novikovo
    http://api.openweathermap.org/data/2.5/weather?appid=a412e057dbaa5b5779d43d4e78580b64&units=imperial&q=novikovo
    Processing Record 523 | blagoyevo
    http://api.openweathermap.org/data/2.5/weather?appid=a412e057dbaa5b5779d43d4e78580b64&units=imperial&q=blagoyevo
    Processing Record 524 | norman wells
    http://api.openweathermap.org/data/2.5/weather?appid=a412e057dbaa5b5779d43d4e78580b64&units=imperial&q=norman%20wells
    Processing Record 525 | butaritari
    http://api.openweathermap.org/data/2.5/weather?appid=a412e057dbaa5b5779d43d4e78580b64&units=imperial&q=butaritari
    Processing Record 526 | barillas
    http://api.openweathermap.org/data/2.5/weather?appid=a412e057dbaa5b5779d43d4e78580b64&units=imperial&q=barillas
    Processing Record 527 | san cristobal
    http://api.openweathermap.org/data/2.5/weather?appid=a412e057dbaa5b5779d43d4e78580b64&units=imperial&q=san%20cristobal
    Processing Record 528 | manali
    http://api.openweathermap.org/data/2.5/weather?appid=a412e057dbaa5b5779d43d4e78580b64&units=imperial&q=manali
    Processing Record 529 | claveria
    http://api.openweathermap.org/data/2.5/weather?appid=a412e057dbaa5b5779d43d4e78580b64&units=imperial&q=claveria
    Processing Record 530 | yumen
    http://api.openweathermap.org/data/2.5/weather?appid=a412e057dbaa5b5779d43d4e78580b64&units=imperial&q=yumen
    Processing Record 531 | bargal
    http://api.openweathermap.org/data/2.5/weather?appid=a412e057dbaa5b5779d43d4e78580b64&units=imperial&q=bargal
    No record for city:bargal
    Processing Record 532 | slave lake
    http://api.openweathermap.org/data/2.5/weather?appid=a412e057dbaa5b5779d43d4e78580b64&units=imperial&q=slave%20lake
    Processing Record 533 | pittsburg
    http://api.openweathermap.org/data/2.5/weather?appid=a412e057dbaa5b5779d43d4e78580b64&units=imperial&q=pittsburg
    Processing Record 534 | saskylakh
    http://api.openweathermap.org/data/2.5/weather?appid=a412e057dbaa5b5779d43d4e78580b64&units=imperial&q=saskylakh
    Processing Record 535 | chazuta
    http://api.openweathermap.org/data/2.5/weather?appid=a412e057dbaa5b5779d43d4e78580b64&units=imperial&q=chazuta
    Processing Record 536 | hit
    http://api.openweathermap.org/data/2.5/weather?appid=a412e057dbaa5b5779d43d4e78580b64&units=imperial&q=hit
    Processing Record 537 | kruisfontein
    http://api.openweathermap.org/data/2.5/weather?appid=a412e057dbaa5b5779d43d4e78580b64&units=imperial&q=kruisfontein
    Processing Record 538 | georgetown
    http://api.openweathermap.org/data/2.5/weather?appid=a412e057dbaa5b5779d43d4e78580b64&units=imperial&q=georgetown
    Processing Record 539 | jiexiu
    http://api.openweathermap.org/data/2.5/weather?appid=a412e057dbaa5b5779d43d4e78580b64&units=imperial&q=jiexiu
    Processing Record 540 | belmonte
    http://api.openweathermap.org/data/2.5/weather?appid=a412e057dbaa5b5779d43d4e78580b64&units=imperial&q=belmonte
    Processing Record 541 | te anau
    http://api.openweathermap.org/data/2.5/weather?appid=a412e057dbaa5b5779d43d4e78580b64&units=imperial&q=te%20anau
    Processing Record 542 | gzhatsk
    http://api.openweathermap.org/data/2.5/weather?appid=a412e057dbaa5b5779d43d4e78580b64&units=imperial&q=gzhatsk
    No record for city:gzhatsk
    Processing Record 543 | aksu
    http://api.openweathermap.org/data/2.5/weather?appid=a412e057dbaa5b5779d43d4e78580b64&units=imperial&q=aksu
    Processing Record 544 | hamilton
    http://api.openweathermap.org/data/2.5/weather?appid=a412e057dbaa5b5779d43d4e78580b64&units=imperial&q=hamilton
    Processing Record 545 | padang
    http://api.openweathermap.org/data/2.5/weather?appid=a412e057dbaa5b5779d43d4e78580b64&units=imperial&q=padang
    Processing Record 546 | homer
    http://api.openweathermap.org/data/2.5/weather?appid=a412e057dbaa5b5779d43d4e78580b64&units=imperial&q=homer
    Processing Record 547 | tura
    http://api.openweathermap.org/data/2.5/weather?appid=a412e057dbaa5b5779d43d4e78580b64&units=imperial&q=tura
    Processing Record 548 | hay river
    http://api.openweathermap.org/data/2.5/weather?appid=a412e057dbaa5b5779d43d4e78580b64&units=imperial&q=hay%20river
    Processing Record 549 | salinopolis
    http://api.openweathermap.org/data/2.5/weather?appid=a412e057dbaa5b5779d43d4e78580b64&units=imperial&q=salinopolis
    Processing Record 550 | codrington
    http://api.openweathermap.org/data/2.5/weather?appid=a412e057dbaa5b5779d43d4e78580b64&units=imperial&q=codrington
    Processing Record 551 | abbeyfeale
    http://api.openweathermap.org/data/2.5/weather?appid=a412e057dbaa5b5779d43d4e78580b64&units=imperial&q=abbeyfeale
    Processing Record 552 | nam tha
    http://api.openweathermap.org/data/2.5/weather?appid=a412e057dbaa5b5779d43d4e78580b64&units=imperial&q=nam%20tha
    No record for city:nam tha
    Processing Record 553 | ribeira brava
    http://api.openweathermap.org/data/2.5/weather?appid=a412e057dbaa5b5779d43d4e78580b64&units=imperial&q=ribeira%20brava
    Processing Record 554 | dombarovskiy
    http://api.openweathermap.org/data/2.5/weather?appid=a412e057dbaa5b5779d43d4e78580b64&units=imperial&q=dombarovskiy
    Processing Record 555 | dalby
    http://api.openweathermap.org/data/2.5/weather?appid=a412e057dbaa5b5779d43d4e78580b64&units=imperial&q=dalby
    Processing Record 556 | krasnoarmeysk
    http://api.openweathermap.org/data/2.5/weather?appid=a412e057dbaa5b5779d43d4e78580b64&units=imperial&q=krasnoarmeysk
    Processing Record 557 | naze
    http://api.openweathermap.org/data/2.5/weather?appid=a412e057dbaa5b5779d43d4e78580b64&units=imperial&q=naze
    Processing Record 558 | wulanhaote
    http://api.openweathermap.org/data/2.5/weather?appid=a412e057dbaa5b5779d43d4e78580b64&units=imperial&q=wulanhaote
    No record for city:wulanhaote
    Processing Record 559 | amarillo
    http://api.openweathermap.org/data/2.5/weather?appid=a412e057dbaa5b5779d43d4e78580b64&units=imperial&q=amarillo
    Processing Record 560 | gravdal
    http://api.openweathermap.org/data/2.5/weather?appid=a412e057dbaa5b5779d43d4e78580b64&units=imperial&q=gravdal
    Processing Record 561 | albany
    http://api.openweathermap.org/data/2.5/weather?appid=a412e057dbaa5b5779d43d4e78580b64&units=imperial&q=albany
    Processing Record 562 | khasan
    http://api.openweathermap.org/data/2.5/weather?appid=a412e057dbaa5b5779d43d4e78580b64&units=imperial&q=khasan
    Processing Record 563 | ndago
    http://api.openweathermap.org/data/2.5/weather?appid=a412e057dbaa5b5779d43d4e78580b64&units=imperial&q=ndago
    Processing Record 564 | sainte-marie
    http://api.openweathermap.org/data/2.5/weather?appid=a412e057dbaa5b5779d43d4e78580b64&units=imperial&q=sainte-marie
    Processing Record 565 | shimoda
    http://api.openweathermap.org/data/2.5/weather?appid=a412e057dbaa5b5779d43d4e78580b64&units=imperial&q=shimoda
    Processing Record 566 | appleton
    http://api.openweathermap.org/data/2.5/weather?appid=a412e057dbaa5b5779d43d4e78580b64&units=imperial&q=appleton
    Processing Record 567 | vila franca do campo
    http://api.openweathermap.org/data/2.5/weather?appid=a412e057dbaa5b5779d43d4e78580b64&units=imperial&q=vila%20franca%20do%20campo
    Processing Record 568 | bredasdorp
    http://api.openweathermap.org/data/2.5/weather?appid=a412e057dbaa5b5779d43d4e78580b64&units=imperial&q=bredasdorp
    Processing Record 569 | hobart
    http://api.openweathermap.org/data/2.5/weather?appid=a412e057dbaa5b5779d43d4e78580b64&units=imperial&q=hobart
    Processing Record 570 | lixourion
    http://api.openweathermap.org/data/2.5/weather?appid=a412e057dbaa5b5779d43d4e78580b64&units=imperial&q=lixourion
    Processing Record 571 | jiaozhou
    http://api.openweathermap.org/data/2.5/weather?appid=a412e057dbaa5b5779d43d4e78580b64&units=imperial&q=jiaozhou
    Processing Record 572 | minden
    http://api.openweathermap.org/data/2.5/weather?appid=a412e057dbaa5b5779d43d4e78580b64&units=imperial&q=minden
    Processing Record 573 | yellowknife
    http://api.openweathermap.org/data/2.5/weather?appid=a412e057dbaa5b5779d43d4e78580b64&units=imperial&q=yellowknife
    Processing Record 574 | alice springs
    http://api.openweathermap.org/data/2.5/weather?appid=a412e057dbaa5b5779d43d4e78580b64&units=imperial&q=alice%20springs
    Processing Record 575 | shellbrook
    http://api.openweathermap.org/data/2.5/weather?appid=a412e057dbaa5b5779d43d4e78580b64&units=imperial&q=shellbrook
    Processing Record 576 | jiddah
    http://api.openweathermap.org/data/2.5/weather?appid=a412e057dbaa5b5779d43d4e78580b64&units=imperial&q=jiddah
    No record for city:jiddah
    Processing Record 577 | anadyr
    http://api.openweathermap.org/data/2.5/weather?appid=a412e057dbaa5b5779d43d4e78580b64&units=imperial&q=anadyr
    Processing Record 578 | beneditinos
    http://api.openweathermap.org/data/2.5/weather?appid=a412e057dbaa5b5779d43d4e78580b64&units=imperial&q=beneditinos
    Processing Record 579 | uk
    http://api.openweathermap.org/data/2.5/weather?appid=a412e057dbaa5b5779d43d4e78580b64&units=imperial&q=uk
    No record for city:uk
    Processing Record 580 | san jose de guanipa
    http://api.openweathermap.org/data/2.5/weather?appid=a412e057dbaa5b5779d43d4e78580b64&units=imperial&q=san%20jose%20de%20guanipa
    Processing Record 581 | great yarmouth
    http://api.openweathermap.org/data/2.5/weather?appid=a412e057dbaa5b5779d43d4e78580b64&units=imperial&q=great%20yarmouth
    Processing Record 582 | makaha
    http://api.openweathermap.org/data/2.5/weather?appid=a412e057dbaa5b5779d43d4e78580b64&units=imperial&q=makaha
    Processing Record 583 | kemijarvi
    http://api.openweathermap.org/data/2.5/weather?appid=a412e057dbaa5b5779d43d4e78580b64&units=imperial&q=kemijarvi
    No record for city:kemijarvi
    Processing Record 584 | lolua
    http://api.openweathermap.org/data/2.5/weather?appid=a412e057dbaa5b5779d43d4e78580b64&units=imperial&q=lolua
    No record for city:lolua
    Processing Record 585 | jacareacanga
    http://api.openweathermap.org/data/2.5/weather?appid=a412e057dbaa5b5779d43d4e78580b64&units=imperial&q=jacareacanga
    Processing Record 586 | emba
    http://api.openweathermap.org/data/2.5/weather?appid=a412e057dbaa5b5779d43d4e78580b64&units=imperial&q=emba
    Processing Record 587 | nemuro
    http://api.openweathermap.org/data/2.5/weather?appid=a412e057dbaa5b5779d43d4e78580b64&units=imperial&q=nemuro
    Processing Record 588 | najran
    http://api.openweathermap.org/data/2.5/weather?appid=a412e057dbaa5b5779d43d4e78580b64&units=imperial&q=najran
    Processing Record 589 | adana
    http://api.openweathermap.org/data/2.5/weather?appid=a412e057dbaa5b5779d43d4e78580b64&units=imperial&q=adana
    Processing Record 590 | monrovia
    http://api.openweathermap.org/data/2.5/weather?appid=a412e057dbaa5b5779d43d4e78580b64&units=imperial&q=monrovia
    Processing Record 591 | port-gentil
    http://api.openweathermap.org/data/2.5/weather?appid=a412e057dbaa5b5779d43d4e78580b64&units=imperial&q=port-gentil
    Processing Record 592 | wenatchee
    http://api.openweathermap.org/data/2.5/weather?appid=a412e057dbaa5b5779d43d4e78580b64&units=imperial&q=wenatchee
    Processing Record 593 | ahuimanu
    http://api.openweathermap.org/data/2.5/weather?appid=a412e057dbaa5b5779d43d4e78580b64&units=imperial&q=ahuimanu
    Processing Record 594 | along
    http://api.openweathermap.org/data/2.5/weather?appid=a412e057dbaa5b5779d43d4e78580b64&units=imperial&q=along
    Processing Record 595 | ixtapa
    http://api.openweathermap.org/data/2.5/weather?appid=a412e057dbaa5b5779d43d4e78580b64&units=imperial&q=ixtapa
    Processing Record 596 | eucaliptus
    http://api.openweathermap.org/data/2.5/weather?appid=a412e057dbaa5b5779d43d4e78580b64&units=imperial&q=eucaliptus
    Processing Record 597 | uddevalla
    http://api.openweathermap.org/data/2.5/weather?appid=a412e057dbaa5b5779d43d4e78580b64&units=imperial&q=uddevalla
    Processing Record 598 | gondar
    http://api.openweathermap.org/data/2.5/weather?appid=a412e057dbaa5b5779d43d4e78580b64&units=imperial&q=gondar
    Processing Record 599 | nome
    http://api.openweathermap.org/data/2.5/weather?appid=a412e057dbaa5b5779d43d4e78580b64&units=imperial&q=nome
    Processing Record 600 | myitkyina
    http://api.openweathermap.org/data/2.5/weather?appid=a412e057dbaa5b5779d43d4e78580b64&units=imperial&q=myitkyina
    Processing Record 601 | sinkat
    http://api.openweathermap.org/data/2.5/weather?appid=a412e057dbaa5b5779d43d4e78580b64&units=imperial&q=sinkat
    No record for city:sinkat
    Processing Record 602 | acari
    http://api.openweathermap.org/data/2.5/weather?appid=a412e057dbaa5b5779d43d4e78580b64&units=imperial&q=acari
    Processing Record 603 | thunder bay
    http://api.openweathermap.org/data/2.5/weather?appid=a412e057dbaa5b5779d43d4e78580b64&units=imperial&q=thunder%20bay
    Processing Record 604 | darhan
    http://api.openweathermap.org/data/2.5/weather?appid=a412e057dbaa5b5779d43d4e78580b64&units=imperial&q=darhan
    Processing Record 605 | saint-doulchard
    http://api.openweathermap.org/data/2.5/weather?appid=a412e057dbaa5b5779d43d4e78580b64&units=imperial&q=saint-doulchard
    Processing Record 606 | athabasca
    http://api.openweathermap.org/data/2.5/weather?appid=a412e057dbaa5b5779d43d4e78580b64&units=imperial&q=athabasca
    Processing Record 607 | olafsvik
    http://api.openweathermap.org/data/2.5/weather?appid=a412e057dbaa5b5779d43d4e78580b64&units=imperial&q=olafsvik
    No record for city:olafsvik
    Processing Record 608 | san borja
    http://api.openweathermap.org/data/2.5/weather?appid=a412e057dbaa5b5779d43d4e78580b64&units=imperial&q=san%20borja
    Processing Record 609 | rimbey
    http://api.openweathermap.org/data/2.5/weather?appid=a412e057dbaa5b5779d43d4e78580b64&units=imperial&q=rimbey
    Processing Record 610 | qaanaaq
    http://api.openweathermap.org/data/2.5/weather?appid=a412e057dbaa5b5779d43d4e78580b64&units=imperial&q=qaanaaq
    Processing Record 611 | gavle
    http://api.openweathermap.org/data/2.5/weather?appid=a412e057dbaa5b5779d43d4e78580b64&units=imperial&q=gavle
    Processing Record 612 | gibgos
    http://api.openweathermap.org/data/2.5/weather?appid=a412e057dbaa5b5779d43d4e78580b64&units=imperial&q=gibgos
    Processing Record 613 | caraballeda
    http://api.openweathermap.org/data/2.5/weather?appid=a412e057dbaa5b5779d43d4e78580b64&units=imperial&q=caraballeda
    Processing Record 614 | junin
    http://api.openweathermap.org/data/2.5/weather?appid=a412e057dbaa5b5779d43d4e78580b64&units=imperial&q=junin
    Processing Record 615 | hasaki
    http://api.openweathermap.org/data/2.5/weather?appid=a412e057dbaa5b5779d43d4e78580b64&units=imperial&q=hasaki
    Processing Record 616 | katsuura
    http://api.openweathermap.org/data/2.5/weather?appid=a412e057dbaa5b5779d43d4e78580b64&units=imperial&q=katsuura
    ------------------------------
    Data Retrieval Complete
    ------------------------------
    


```python
# create a data frame of all data requested
weather_dict = {
    "City": name,
    "Country": country,
    "Latitude": lat,
    "Longitude":lon,
    "Temperature (F)": max_temp,
    "Humidity (%)": humidity,
    "Cloudiness (%)":clouds,
    "Wind Speed (mph)":wind_speed
}
weather_data = pd.DataFrame(weather_dict)
weather_data.count()
```




    City                546
    Cloudiness (%)      546
    Country             546
    Humidity (%)        546
    Latitude            546
    Longitude           546
    Temperature (F)     546
    Wind Speed (mph)    546
    dtype: int64




```python
weather_data.head()
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
      <th>City</th>
      <th>Cloudiness (%)</th>
      <th>Country</th>
      <th>Humidity (%)</th>
      <th>Latitude</th>
      <th>Longitude</th>
      <th>Temperature (F)</th>
      <th>Wind Speed (mph)</th>
    </tr>
  </thead>
  <tbody>
    <tr>
      <th>0</th>
      <td>Saint-Pierre</td>
      <td>0</td>
      <td>FR</td>
      <td>57</td>
      <td>48.95</td>
      <td>4.24</td>
      <td>80.60</td>
      <td>9.17</td>
    </tr>
    <tr>
      <th>1</th>
      <td>Warangal</td>
      <td>0</td>
      <td>IN</td>
      <td>49</td>
      <td>17.99</td>
      <td>79.60</td>
      <td>89.62</td>
      <td>13.89</td>
    </tr>
    <tr>
      <th>2</th>
      <td>Strezhevoy</td>
      <td>90</td>
      <td>RU</td>
      <td>64</td>
      <td>60.73</td>
      <td>77.60</td>
      <td>33.80</td>
      <td>4.47</td>
    </tr>
    <tr>
      <th>3</th>
      <td>Guiratinga</td>
      <td>0</td>
      <td>BR</td>
      <td>34</td>
      <td>-16.35</td>
      <td>-53.76</td>
      <td>90.16</td>
      <td>9.86</td>
    </tr>
    <tr>
      <th>4</th>
      <td>Muros</td>
      <td>75</td>
      <td>ES</td>
      <td>87</td>
      <td>42.77</td>
      <td>-9.06</td>
      <td>59.00</td>
      <td>10.29</td>
    </tr>
  </tbody>
</table>
</div>




```python
weather_data.to_csv('weather_data.csv', index=False)
```

## Latitude vs Temperature Plot


```python

plt.scatter(weather_data["Latitude"], weather_data["Temperature (F)"], marker="o", c="blue", edgecolors="black")


plt.title("City Latitude vs. Max Temperature (05/25/18)")
plt.ylabel("Max Temperature (F)")
plt.xlabel("Latitude")
plt.grid(True)

# Save the figure
plt.savefig("Latitude_Max Temperature.png")

plt.show()
```


![png](output_11_0.png)


##### Findings:
- Based on the weather data on May 25 2018, maximum temperatures of sample cities are at peak when cities' latitudes are around 20.
- The maximum temperature is about 115 F.
- Temperatures are warmmer as it approaches the Equator and cooler approaching the Poles.

## Latitude vs. Humidity Plot


```python

plt.scatter(weather_data["Latitude"], weather_data["Humidity (%)"], marker="o", c="blue", edgecolors="black")


plt.title("City Latitude vs. Humidity (05/25/18)")
plt.ylabel("Humidity (%)")
plt.xlabel("Latitude")
plt.grid(True)

plt.savefig("City Latitude_Humidity.png")

plt.show()
```


![png](output_14_0.png)


##### Findings:
- Humidity reaches 100% in large amount of cities with latitude between -20 and 20. However, cities with higher latitude (e.g.60) also can have high humidity.
- Cities have higher humidity counts more than cities with lower humidity.
- Humidity and Latitude do not have significant relationship.

## Latitude vs. Cloudiness Plot


```python

plt.scatter(weather_data["Latitude"], weather_data["Cloudiness (%)"], marker="o", c="blue", edgecolors="black")


plt.title("City Latitude vs. Cloudiness (05/25/18)")
plt.ylabel("Cloudiness (%)")
plt.xlabel("Latitude")
plt.grid(True)


plt.savefig("City Latitude_Cloudiness.png")

plt.show()
```


![png](output_17_0.png)


##### Findings:
- Cloudiness are evenly spread in sample cities. 
- Cloudiness and Latitude do not have significant relationship.


## Latitude vs. Wind Speed Plot


```python

plt.scatter(weather_data["Latitude"], weather_data["Wind Speed (mph)"], marker="o", c="blue", edgecolors="black")


plt.title("City Latitude vs. Wind Speed (05/25/18)")
plt.ylabel("Wind Speed (mph)")
plt.xlabel("Latitude")
plt.grid(True)

plt.savefig("City Latitude_Wind Speed.png")

plt.show()
```


![png](output_20_0.png)


##### Findings:
- Wind speed of sample cities mostly land on range 0 to 15. 
- No significant relation between Latitude and Wind Speed.
