import React, { useState } from 'react';
import Table from 'react-bootstrap/Table';

function UnderView() {
  return (
    <div>
      <h3 className="pt-4">Under Review</h3>
      <Table striped bordered hover>
        <thead class="thead-dark">
          <tr >
            <th>S.no</th>
            <th>Idea</th>
            <th>Status</th>
            <th>Estimated  cost saving</th>
            <th>Comments</th>
          </tr>
        </thead>
        <tbody>
          <tr>
            <td>1</td>
            <td></td>
            <td>under review</td>
            <td></td>
            <td>
              <button >Redirect</button>
            </td>
          </tr>
          <tr>
            <td>2</td>
            <td></td>
            <td>under review</td>
            <td></td>
            <td></td>
          </tr>
        </tbody>
      </Table>
    </div>
  );
}

export default UnderView;