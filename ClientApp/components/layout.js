import PageContainer from './page-container';
import Index from './header';
import React from 'react';

export default function Layout({ children }) {
  return (
    <PageContainer>
      <Index/>
      {children}
    </PageContainer>
  );
}
