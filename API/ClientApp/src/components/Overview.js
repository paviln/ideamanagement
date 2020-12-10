import React, { useState, useEffect } from 'react';
import moment from 'moment';
import DatePicker from "react-datepicker";
import ideaService from '../services/IdeaService';
import Table from 'react-bootstrap/Table';

const Overview = () => {

  const [ideas, setIdeas] = useState([]);
  const [startDate, setStartDate] = useState(new Date("2020/11/01"));
  const [endDate, setEndDate] = useState(new Date("2020/12/31"));

  useEffect(() => {
    async function fetchData() {
      try {
        var start = moment(startDate).format("MM/DD/YYYY, HH:mm:ss");
        var end = endDate;
        end.setHours(23);
        end.setMinutes(59);
        end.setSeconds(59)
        end = moment(end).format("MM/DD/YYYY, HH:mm:ss");
        var period = [start, end];
        const response = await ideaService.getIdeasPeriod(period);
        setIdeas(response.data);
      } catch (error) {
        console.log(error);
      }
    }
    fetchData();
  }, [startDate, endDate]);

  const populateIdeas = () => {
    if (ideas.length > 0) {
      const list = [];
      for (let i = 0; i < ideas.length; i++) {
        list.push(
          <tr key={i}>
            <td>{ideas[i].ideaId}</td>
            <td>{ideas[i].title}</td>
          </tr>
        );
      }

      return list;
    }

    return null;
  }
  return (
    <div>
      <h3 className="pt-4">Ideas</h3>
      <div className="pt-2">
        <div className="pr-2 pb-2 float-left">
          <p>Start date</p>
          <DatePicker
            selected={startDate}
            onChange={date => setStartDate(date)}
            selectsStart
            startDate={startDate}
            endDate={endDate}
            dateFormat="dd/MM/yyyy"
          />
        </div>
        <div className="pb-2 float-left">
          <p>End date</p>
          <DatePicker
            selected={endDate}
            onChange={date => setEndDate(date)}
            selectsEnd
            startDate={startDate}
            endDate={endDate}
            minDate={startDate}
            dateFormat="dd/MM/yyyy"
          />
        </div>
      </div>
      <Table className="mt-4" striped bordered hover>
        <thead className="thead-dark">
          <tr>
            <th>S.no</th>
            <th>Title</th>
          </tr>
        </thead>
        <tbody>
          {populateIdeas()}
        </tbody>
      </Table>
    </div>
  );
}

export default Overview
