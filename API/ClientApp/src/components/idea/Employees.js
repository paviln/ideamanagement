import React from 'react'

function Employees(props) {

  const populateEmployees = (employees) => {
    const list = [];

    if (employees !== null) {
      for (let i = 0; i < employees.length; i++) {
        list.push(
          <li>
            <p>{employees[i].name} ({employees[i].position}) </p>
          </li>
        );
      }
    }

    return list;
  }

  var list = populateEmployees(props.employees);

  if (list.length > 0) {
    return (
      <div>
        <h5 className="pt-2">Connected Employees</h5>
        <ul className="m-0">
          {list}
        </ul>
      </div>
    );
  }

  return null;
}

export default Employees
