import React from 'react';
import Hidden from '@material-ui/core/Hidden';
import RidesToolbar from './rides-toolbar';
import RideItem from './ride-item/ride-item';

export default function RidesList() {
  const rides = [
    {
      id: 2324,
      rideDate: 'Today',
      rideTime: '10:33',
      settings: 'settings',
      description: 'description',
      name: 'gela',
      plateNumber: 'ANZ-224',
      driver: 'გელა',
      rating: 4
    },
    {
      id: 2323,
      rideDate: 'თომორროწ',
      rideTime: '11:45',
      settings: 'settings',
      description: 'description',
      name: 'ნუგო',
      plateNumber: 'ANZ-224',
      driver: 'ნუგო',
      rating: 4
    },
    {
      id: 2329,
      rideDate: 'თომორროწ',
      rideTime: '11:45',
      settings: 'settings',
      description: 'description',
      name: 'ნუგო',
      plateNumber: 'ANZ-224',
      driver: 'ნუგო',
      rating: 4
    }
  ];

  return (
    <div>
      <Hidden smDown>
        <RidesToolbar/>
      </Hidden>
      {rides.map(ride => (
        <RideItem
          key={ride.id}
          rideDate={ride.rideDate}
          rideTime={ride.rideTime}
          settings={ride.settings}
          description={ride.description}
          bookedSeats={ride.bookedSeats}
          plateNumber={ride.plateNumber}
          driver={ride.driver}
          onClick={() => void 0}
        />
      ))}
    </div>
  );
}
