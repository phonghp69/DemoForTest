import React, { useEffect, useState } from "react";
import { useParams } from "react-router-dom";
import Typography from "@mui/material/Typography";
import { makeStyles } from "@mui/styles";
import { Paper } from "@mui/material";

const styles = makeStyles({
  wrapper: {
    width: "65%",
    margin: "auto",
    textAlign: "center",
  },
  bigSpace: {
    marginTop: "5rem",
  },
  littleSpace: {
    marginTop: "2.5rem",
    marginBottom: "2.5rem",
  },
});
export default function AssetDetail() {
  const { id } = useParams();
  useEffect(() => {
    fetchItem();
  }, []);

  const [item, setItem] = useState({});

  const fetchItem = async () => {
    const fetchItem = await fetch(`${process.env.Backend_URI}/Asset/${id}`);
    const item = await fetchItem.json();
    setItem(item);
  };

  const classes = styles();
  return (
    <div>
      <div className={classes.wrapper}>
        <Paper elevation={3}>
            <Typography variant="h4" className={classes.littleSpace} color="secondary" align="left" sx={{ margin: 2}}>
            Detailed Assignment Information
          </Typography>
          
          <Typography
            variant="h6"
            align="left" sx={{ margin: 2}}
          >
            Asset Code: <span></span>
            {item.assetCode}
          </Typography>
          <Typography
            variant="h6"
            align="left" sx={{ margin: 2}}
          >
            Asset Name: <span></span>
            {item.assetName}
          </Typography>
          <Typography
            variant="h6"
            align="left" sx={{ margin: 2}}
          >
            Specification: <span></span>
            {item.specification}
          </Typography>
          <Typography
            variant="h6"
            align="left" sx={{ margin: 2}}
          >
            Assigned Date: <span></span>
            {item.installedDate}
          </Typography>
          <Typography
            variant="h6"
            align="left" sx={{ margin: 2}}
          >
            State: <span></span>
            {item.assetState}
          </Typography>
        </Paper>
      </div>
    </div>
  );
}
