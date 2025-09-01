export const Tel = (props: { tel: number }) => (
  <a href={`tel:${props.tel}`}>{props.tel}</a>
);
