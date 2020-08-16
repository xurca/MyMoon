import PageContainer from './page-container';
import Header from './header';
import React from 'react';
import Footer from './footer';

export default function Layout({ children }) {
  return (
    <PageContainer>
      <Header/>
      {children}
      <Footer/>
    </PageContainer>
  );
}
