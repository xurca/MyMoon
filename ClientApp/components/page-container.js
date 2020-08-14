import Head from 'next/head';
import { APP_NAME } from '../lib/constants';

export default function PageContainer({ title, description, children, shouldIndex = true }) {
  return (
    <div>
      <Head>
        <title>{title || 'Ride Sharing'}</title>
        {description !== false && (
          <meta
            name="description"
            content={description || APP_NAME}
          />
        )}
        {!shouldIndex && <meta name="robots" content="noindex" />}
      </Head>
      {children}
    </div>
  );
}
