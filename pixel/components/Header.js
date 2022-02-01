import React from 'react';
import Image from 'next/image'
import logo from '../images/logo.png'

export default function Header() {
  return (
      <>
        <nav className="navbar navbar-light bg-light">
            <div className="container-fluid">
                <a className="navbar-brand" href="#">
                    <Image src={logo} alt="" width="60" height="48" className="d-inline-block align-text-top"/>
                </a>
            </div>
        </nav>
      </>
  ) 
    
}
