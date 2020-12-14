import React, {useState, useEffect} from 'react';
import {useHistory} from 'react-router-dom'
import moment from 'moment';
import DatePicker from "react-datepicker";
import Row from 'react-bootstrap/Row';
import Col from 'react-bootstrap/Col';
import ideaService from '../services/IdeaService';
import Table from './Table';

const Overview = (props) => {
  const history = useHistory();
  const [loading, setLoading] = useState(true);
  const [ideas, setIdeas] = useState([]);
  const [startDate, setStartDate] = useState(new Date());
  const [endDate, setEndDate] = useState(new Date());
  const [minDate, setMinDate] = useState(new Date());
  const [maxDate, setMaxDate] = useState(new Date());

  useEffect(() => {
    async function fetchData() {
      try {
        var response = await ideaService.getPeriod();
        setMinDate(new Date(response.data[0]));
        setMaxDate(new Date(response.data[1]));
        setStartDate(new Date(response.data[0]));
        setEndDate(new Date(response.data[1]));
      } catch (error) {
        console.log(error);
      }
    }
    fetchData();
  }, []);

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

  const handleClick = (ideaId) => {
    history.push({
      pathname: props.prefix + "/overview/" + ideaId,
    });
  }
  
  return (
    <div>
      <h3 className="pt-4">Ideas</h3>
      <div className="pt-2 clearfix">
        <div className="pr-2 pb-2 float-left">
          <p>From</p>
          <DatePicker
            selected={startDate}
            onChange={date => setStartDate(date)}
            selectsStart
            startDate={startDate}
            endDate={endDate}
            minDate={minDate}
            maxDate={endDate}
            dateFormat="dd/MM/yyyy"
          />
        </div>
        <div className="pb-2 float-left">
          <p>To</p>
          <DatePicker
            selected={endDate}
            onChange={date => setEndDate(date)}
            selectsEnd
            startDate={startDate}
            endDate={endDate}
            minDate={startDate}
            maxDate={maxDate}
            dateFormat="dd/MM/yyyy"
          />
        </div>
      </div>
      <Row>
        <Col sm={12} md={4}>
          <Table title="New" ideas={ideas.filter(f => f.status == '0')} loading={loading} bg="table-success" handleClick={handleClick}/>
        </Col>
        <Col sm={12} md={4}>
          <Table title="In Progress" ideas={ideas.filter(f => f.status == '1' || f.status == '2')} loading={loading} bg="table-warning" handleClick={handleClick} />
        </Col>
        <Col sm={12} md={4}>
          <Table title="Implemented" ideas={ideas.filter(f => f.status == '3')} loading={loading} bg="table-danger" handleClick={handleClick} />
        </Col>
      </Row>
    </div>
  );
}

export default Overview
