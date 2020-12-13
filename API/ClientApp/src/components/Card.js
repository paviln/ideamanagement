import React from 'react'
import BCard from 'react-bootstrap/Card';
import Button from 'react-bootstrap/Button';

function Card() {
  return (
    <div>
      <BCard>
        <BCard.Header as="h5">Featured</BCard.Header>
        <BCard.Body>
          <BCard.Title>Special title treatment</BCard.Title>
          <BCard.Text>
            With supporting text below as a natural lead-in to additional content.
          </BCard.Text>
          <Button variant="primary">Go somewhere</Button>
        </BCard.Body>
      </BCard>
    </div>
  )
}

export default Card
