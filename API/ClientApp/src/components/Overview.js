import React, { useState, useEffect } from 'react';
import moment from 'moment';
import DatePicker from "react-datepicker";
import Row from 'react-bootstrap/Row';
import Col from 'react-bootstrap/Col';
import ideaService from '../services/IdeaService';
import Table from './Table';

const Overview = () => {

  const [loading, setLoading] = useState(true);
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
        setLoading(false);
      } catch (error) {
        console.log(error);
      }
    }
    fetchData();
  }, [startDate, endDate]);
  
  return (
    <div>
      <h3 className="pt-4">Ideas</h3>
      <div className="pt-2 clearfix">
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
      <Row>
        <Col sm={12} md={4}>
          <Table title="New" ideas={ideas} loading={loading} />
        </Col>
        <Col sm={12} md={4}>
          <Table title="In Progress" ideas={ideas} loading={loading} />
        </Col>
        <Col sm={12} md={4}>
          <Table title="Implemented" ideas={ideas} loading={loading} />
        </Col>
      </Row>

    </div>
  );
}

export default Overview
