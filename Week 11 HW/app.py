import datetime as dt
import numpy as np
import pandas as pd

import sqlalchemy
from sqlalchemy.ext.automap import automap_base
from sqlalchemy.orm import Session
from sqlalchemy import create_engine, func

from flask import Flask, jsonify
import json

#################################################
# Database Setup
#################################################
engine = create_engine("sqlite:///hawaii.sqlite", connect_args={'check_same_thread': False})

# reflect an existing database into a new model
Base = automap_base()
# reflect the tables
Base.prepare(engine, reflect=True)

# Save reference to the table
Measurement = Base.classes.measurements
Station = Base.classes.stations

# Create our session (link) from Python to the DB
session = Session(engine)

#################################################
# Flask Setup
#################################################
app = Flask(__name__)


#################################################
# Flask Routes
#################################################

@app.route("/")
def welcome():
    """List all available api routes."""
    return (
        f"Welcome to Hawaii Climate App!<br/>"
        f"<br/>"
        f"Available Routes:<br/>"
        f"<br/>"

        f"Precipitation Data (8/23/16-8/23/17)<br/>"
        f"/api/v1.0/precipitation<br/>"
        f"<br/>"

        f"All the Stations<br/>"
        f"/api/v1.0/stations<br/>"
        f"<br/>"

        f"Temperature Observations (8/23/16-8/23/17)<br/>"
        f"/api/v1.0/tobs<br/>"
        f"<br/>"

        f"Temperature Analysis - Date<br/>"
        f"(Please Enter Any Date From (8/23/16-8/23/17) use format (2016-08-23)) <br/>"
        f"/api/v1.0/<start><br/>"
        f"<br/>"

        f"Temperature Analysis - Period<br/>"
        f"(Please Enter Any Period From (8/23/16-8/23/17) use format (2016-08-23/2016-08-27)) <br/>"
        f"/api/v1.0/<start>/<end><br/>"
    )


# /api/v1.0/precipitation

last_date_YA = dt.date(2017, 8, 23) - dt.timedelta(days=365)

@app.route("/api/v1.0/precipitation")
def precipitation():
    # Query for the dates and temperature observations from the last year.
    precipitation = session.query(Measurement.date, func.avg(Measurement.prcp)).\
                    filter(Measurement.date >= last_date_YA).\
                    group_by(Measurement.date).all()
   
    # Convert the query results to a Dictionary using date as the key and tobs as the value.
    prcp_dict = dict(precipitation)

    # Return the JSON representation of your dictionary.
    return jsonify(prcp_dict)


# /api/v1.0/stations
# Return a JSON list of stations from the dataset.

@app.route("/api/v1.0/stations")
def stations():
    station = session.query(Station.station, Station.name).all()

    station_dict = dict(station)

    return jsonify(station_dict)


# /api/v1.0/tobs
# Return a JSON list of Temperature Observations (tobs) for the previous year

@app.route("/api/v1.0/tobs")
def tobs():
    tobs = session.query(Measurement.date, Measurement.station, Measurement.tobs).\
           filter(Measurement.date >= last_date_YA).all()

    return jsonify(tobs)


# /api/v1.0/<start>
# Return a JSON list of the minimum temperature, the average temperature, and the max temperature\
# for a given start or start-end range.

# When given the start only, calculate TMIN, TAVG, and TMAX for all dates greater than and equal to the start date.
@app.route("/api/v1.0/<start>")
def startDateOnly(start):
    tmp_analysis_date = session.query(func.min(Measurement.tobs), func.avg(Measurement.tobs), func.max(Measurement.tobs)).\
    filter(Measurement.date == start).all()
    
    return jsonify(tmp_analysis_date)


# /api/v1.0/<start>/<end>

# When given the start and the end date, calculate the TMIN, TAVG, and TMAX \
# for dates between the start and end date inclusive.

@app.route("/api/v1.0/<start>/<end>")
def startDateEndDate(start,end):
    tmp_analysis_period = session.query(func.min(Measurement.tobs), func.avg(Measurement.tobs), func.max(Measurement.tobs)).\
    filter(Measurement.date >= start).\
    filter(Measurement.date <= end).all()

    return jsonify(tmp_analysis_period)

if __name__ == "__main__":
    app.run(debug=True)